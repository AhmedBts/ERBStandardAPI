using Domain.Entities.Views;


namespace Application.Interface.SecurityModule.Master
{
    public interface IPrgPer
    {
        Task<List<UserPermissionDetailView>> showGroupPermission(int userid);
        Task<List<UserPermissionDetailView>> SaveGroupPermission(List<UserPermissionDetailView> GroupPermission);
        Task<List<UserPermissionDetailView>> showGroupPermissionwithparentid(int userID, int Progid);
    }
}
