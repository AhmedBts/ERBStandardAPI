
using Application.Views;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.SecurityModule.Master
{
    public interface IUser:IBaseRepository<User>
    {
        Task<Pager<User>> GetMembersAsync(PageProperties userParams);
        Task<User> Save(UserWithPassword obj);
        Task<User> Update(User obj, string password, byte[]? image);
        Task<bool> UserLogOut();
        Task<List<Program>> GetPrograms(int id, string lang);
        Task<List<staffApproval>> UserToApproval();
        Task<bool> UpdateUserApproval(int Id, int Approval, int groupid);
        Task<IQueryable<ActionUserView>> UserLogFilter(ActionTypeFilter actionTypeFilter);
        Task<User> UpdateImage(ImageDTO image);
        Task<bool> DeleteImage();
        Task<int> Deactivate();
        Task<bool> ChangePassword(ChangePasswordView cpv);

    }
}
