using Application.Interface.SecurityModule.Master;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository.SecurityModule.Master
{
    public class PrgPerRepository : IPrgPer
    {
        readonly HUB_Context db;


        public PrgPerRepository(HUB_Context db)
        {
            this.db = db;
        }
        public async Task<List<UserPermissionDetailView>> SaveGroupPermission(List<UserPermissionDetailView> GroupPermission)
        {
            try
            {
                List<PrgPer> xobj = await db.PrgPer.Where(
                    t => t.UserId == GroupPermission[0].UserId
                    ).ToListAsync();
                var groupsave = xobj.Where(item =>

GroupPermission.Any(category => category.ProgId.Equals(item.ProgId))).ToList();
                db.PrgPer.RemoveRange(groupsave);
                await db.SaveChangesAsync();
                PrgPer x2 = new PrgPer();
                var listtosave = GroupPermission.Where(x => x.Read == true || x.Insert == true || x.Print == true || x.Edit == true || x.Delete == true).ToList();
                foreach (UserPermissionDetailView newList in listtosave)
                {
                    if (newList.Insert == true || newList.Delete == true || newList.Edit == true
                         || newList.Print == true || newList.Read == true)
                    {


                        x2.ProgId = newList.ProgId;
                        x2.Insert = newList.Insert;
                        x2.Edit = newList.Edit;
                        x2.Read = newList.Read;
                        x2.Delete = newList.Delete;
                        x2.Print = newList.Print;

                        x2.UserId = newList.UserId;
                        await db.PrgPer.AddAsync(x2);

                        x2 = new PrgPer();
                    }
                }
                await db.SaveChangesAsync();
                return GroupPermission;
            }
            catch
            {
                return null;
            }

        }

        [Obsolete]
        public async Task<List<UserPermissionDetailView>> showGroupPermission(int userid)
        {

            try
            {
                List<Program> programs = await db.Programs.ToListAsync();
                List<PrgPer> GPList = new List<PrgPer>();
                GPList = await db.PrgPer.Where(x => x.UserId == userid).ToListAsync();
                List<UserPermissionDetailView> lst = new List<UserPermissionDetailView>();
                UserPermissionDetailView detailView = new UserPermissionDetailView();

                List<UserPermissionDetailView> result = GPList.Where(item =>
item.UserId == userid &&
    programs.Any(category => category.ProgId.Equals(item.ProgId))).Select(x => new UserPermissionDetailView
    {
        ProgId = x.ProgId,
        ArabicName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ArabicName).FirstOrDefault(),
        Delete = x.Delete,
        Edit = x.Edit,

        GroupCode = 1,
        Insert = x.Insert,
        LatinName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.LatinName).FirstOrDefault(),
        ParentId = (decimal)programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ParentId).FirstOrDefault(),
        Print = x.Print,
        Read = x.Read,

    }).ToList().Union(
                       programs.Where(
 x => !GPList.Any(y => y.ProgId == x.ProgId)).Select(x => new UserPermissionDetailView
 {
     ProgId = x.ProgId,
     ArabicName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ArabicName).FirstOrDefault(),
     Delete = false,
     Edit = false,

     GroupCode = 1,
     Insert = false,
     LatinName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.LatinName).FirstOrDefault(),
     ParentId = (decimal)programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ParentId).FirstOrDefault(),
     Print = false,
     Read = false,

 })
                    ).ToList()
            ;


                return result;
            }
            catch (Exception ex)
            {
                return null;
            }



        }


        public async Task<List<UserPermissionDetailView>> showGroupPermissionwithparentid(int userid, int Progid)
        {
            try
            {
                List<Program> programs = await db.Programs.ToListAsync();
                List<PrgPer> GPList = new List<PrgPer>();
                GPList = await db.PrgPer.Where(x => x.UserId == userid).ToListAsync();
                List<UserPermissionDetailView> lst = new List<UserPermissionDetailView>();
                UserPermissionDetailView detailView = new UserPermissionDetailView();

                List<UserPermissionDetailView> result = GPList.Where(item =>
item.UserId == userid &&
    programs.Any(category => category.ProgId.Equals(item.ProgId))).Select(x => new UserPermissionDetailView
    {
        ProgId = x.ProgId,
        ArabicName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ArabicName).FirstOrDefault(),
        Delete = x.Delete,
        Edit = x.Edit,

        GroupCode = 1,
        Insert = x.Insert,
        LatinName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.LatinName).FirstOrDefault(),
        ParentId = (decimal)programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ParentId).FirstOrDefault(),
        Print = x.Print,
        Read = x.Read,

    }).ToList().Union(
                       programs.Where(
 x => !GPList.Any(y => y.ProgId == x.ProgId)).Select(x => new UserPermissionDetailView
 {
     ProgId = x.ProgId,
     ArabicName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ArabicName).FirstOrDefault(),
     Delete = false,
     Edit = false,

     GroupCode = 1,
     Insert = false,
     LatinName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.LatinName).FirstOrDefault(),
     ParentId = (decimal)programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ParentId).FirstOrDefault(),
     Print = false,
     Read = false,

 })
                    ).ToList()
            ;

                var re2 = result.Where(item => item.ParentId == Progid || item.ProgId == Progid

);
                return re2.ToList();




            }
            catch (Exception ex)
            {
                return null;
            }





        }
    }
}