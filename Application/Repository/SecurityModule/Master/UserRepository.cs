
using Application.Interface.SecurityModule.Master;
using Application.Views;
using Common;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Domain.Helpers;
using Domain.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Repository.SecurityModule.Master
{
    public class UserRepository : BaseRepository<User>, IUser
    {

        public UserRepository(HUB_Context context, IUserService userService) : base(context, userService)
        {
        }
        public async Task<bool> UserLogOut()
        {
            var id = _userService.GetUserId();
            if (id == null)
                return false;
            UserLog userLog = new UserLog();
            userLog.UserId = (int)id;
            userLog.CreatedAt = DateTime.Now;
            userLog.IPaddress = _userService.GetUserIdaddress();
            userLog.ActionType = 5;
            _context.UsersLog.Add(userLog);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<User> Save(UserWithPassword obj)
        {
            var exist = await _context.Users.Where(x => x.UserName == obj.User.UserName ||
           x.Email == obj.User.Email).FirstOrDefaultAsync();
            if (exist != null)
            {
                return null;
            }
            byte[] PasswordHash, PasswordSolt;
            SecurityLogic.Instance().CreatePassword(obj.Password, out PasswordHash, out PasswordSolt);
            obj.User.PasswordHash = PasswordHash;
            obj.User.PasswordSolt = PasswordSolt;
            await _context.Users.AddAsync(obj.User);
            await _context.SaveChangesAsync();
            if (obj.Image != null)
            {
                obj.User.PhotoUserPath = await SecurityLogic.Instance().UploadLogoWithBytes(obj.User.Id, obj.Image);
            }
            _context.Users.Update(obj.User);
            UserLog userLog = new UserLog();
            userLog.UserId = obj.User.Id;
            userLog.IPaddress = _userService.GetUserIdaddress();
            userLog.CreatedAt = DateTime.Now;
            userLog.ActionType = 1;
            _context.UsersLog.Add(userLog);
            await _context.SaveChangesAsync();
            return obj.User;
        }

        public async Task<List<staffApproval>> UserToApproval()
        {
            return await (from user in _context.Users
                          where user.Approval == null || user.Approval == false
                          select new staffApproval
                          {
                              Approval = user.Approval,
                              GroupId = (int)user.GroupId,
                              Id = user.Id,
                              Name = user.Name,
                              Username = user.UserName
                          }).ToListAsync();
        }
        public async Task<bool> UpdateUserApproval(int Id, int Approval, int groupid)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user != null)
            {
                user.GroupId = groupid;
                user.Approval = Approval == 0 ? false : true;
                _context.Users.Update(user);

                UserLog userLog = new UserLog();
                userLog.UserId = Id;
                userLog.CreatedAt = DateTime.Now;
                userLog.ActionType = 2;
                userLog.IPaddress = _userService.GetUserIdaddress();
                _context.UsersLog.Add(userLog);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;


        }

        public async Task<User> Update(User obj, string password, byte[]? image)
        {
            var upadetobj = await _context.Users.FindAsync(obj.Id);
            upadetobj.GroupId = obj.GroupId;
            upadetobj.address = obj.address;
            upadetobj.BirthDay = obj.BirthDay;
            upadetobj.UserName = obj.UserName;

            upadetobj.Email = obj.Email;
            upadetobj.Groups = obj.Groups;
            upadetobj.Mobile = obj.Mobile;
            upadetobj.Mobile1 = obj.Mobile1;
            upadetobj.Name = obj.Name;
            upadetobj.NotActive = obj.NotActive;
            upadetobj.PhotoUserPath = obj.PhotoUserPath;
            if (!string.IsNullOrEmpty( password) && password.ValidatePassword())
            {
                byte[] PasswordHash, PasswordSolt;
                SecurityLogic.Instance().CreatePassword(password, out PasswordHash, out PasswordSolt);
                upadetobj.PasswordHash = PasswordHash;
                upadetobj.PasswordSolt = PasswordSolt;
            }
            if (upadetobj != null)
            {
                if(image != null)
                {
                    obj.PhotoUserPath = await SecurityLogic.Instance().UploadLogoWithBytes(obj.Id, image);
                }
                _context.Users.Update(upadetobj);
                await _context.SaveChangesAsync();

            }
          
            return obj;


        }

        public async Task<int> Deactivate()
        {
            var obj = await _context.Users.FindAsync(this._userService.GetUserId());
            obj.NotActive = true;
            _context.Users.Update(obj);
            int entries = _context.SaveChanges();
            return entries;
        }
        public async Task<List<Program>> GetPrograms(int id, string lang)
        {

            var x = await (from a in _context.Programs
                           join xobj in _context.PrgPer on
                         a.ProgId equals xobj.ProgId
                           join uobj in _context.Users
                           on xobj.UserId equals uobj.Id
                           where uobj.Id == id
                           select a).ToListAsync();
            if (x != null && x.Count > 0)
            {
                if (lang == "ar")
                {
                    foreach (var p in x)
                        p.LatinName = p.ArabicName;
                }
                return x;
            }

            x = await (from a in _context.Programs
                       join xobj in _context.GroupPermission on
                     a.ProgId equals xobj.ProgId
                       join uobj in _context.Users
                       on xobj.GroupCode equals uobj.GroupId
                       where uobj.Id == id
                       select a).ToListAsync();
            if (lang == "ar")
            {
                foreach (var p in x)
                    p.LatinName = p.ArabicName;
            }
            return x;
        }

        public async Task<User> UpdateImage(ImageDTO image)
        {
            var obj = await _context.Users.FindAsync(this._userService.GetUserId());
            obj.PhotoUserPath = await SecurityLogic.Instance().UploadLogoWithBytes(obj.Id, image.Image);
            _context.Users.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        public async Task<bool> DeleteImage()
        {
            var obj = await _context.Users.FindAsync(this._userService.GetUserId());
            if (obj.PhotoUserPath != null)
            {
                var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", obj.PhotoUserPath);
                File.Delete(imgPath);
                obj.PhotoUserPath = null;
                _context.Users.Update(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<Pager<User>> GetMembersAsync(PageProperties userParams)
        {
            var x2 =  _context.Users;
           return await x2.Pagination(userParams.PageNumber, userParams.PageSize);
          
        }




        public async Task<bool> ChangePassword(ChangePasswordView cpv)
        {

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(ex => ex.Id == _userService.GetUserId() );
                if (user != null)
                {
                    if (cpv.OldPassword.Verifypasswordhash(user.PasswordSolt, user.PasswordHash))
                    {
                        cpv.NewPassword.CreatePassword(out byte[] hash, out byte[] solt);
                        user.PasswordHash = hash;
                        user.PasswordSolt = solt;
                        _context.Users.Update(user);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;

            }

        }


        public async Task<IQueryable<ActionUserView>> UserLogFilter(ActionTypeFilter actionTypeFilter)
        {


            return (from a in _context.Users
                    join b in _context.UsersLog
                    on a.Id equals b.UserId
                    join c in _context.ActionTypeUser
                    on b.ActionType equals c.Id
                    where actionTypeFilter.UserId == null ? 1 == 1 : a.Id == actionTypeFilter.UserId
                    && b.CreatedAt >= actionTypeFilter.Fromdate &&
                    b.CreatedAt <= actionTypeFilter.Todate
                    select new ActionUserView
                    {
                        Actiondate = b.CreatedAt,
                        Actiontype = c.ActionTypeName,
                        IPaddress = b.IPaddress,
                        UserName = a.UserName

                    }).AsQueryable();



        }




    }
}
