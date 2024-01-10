using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.SecurityModule.Master
{
    public interface IGroupPermission
    {
        Task<List<UserPermissionDetailView>> GetUserPermissionDetails(int GroupCode);
        IQueryable<MenuItemView> GetProgramsByGroup(int GroupCode, bool SysLang);

        Task<List<UserPermissionDetailView>> showGroupPermission(int GroupCode);
        Task<List<UserPermissionDetailView>> showGroupPermissionwithparentid(int GroupCode, int Progid);
        IQueryable<MenuItemView> GetProgramsByGroup(int GroupCode, bool SysLang, decimal ParentID, bool PageYN = false);

        Task<List<UserPermissionDetailView>> SaveGroupPermission(List<UserPermissionDetailView> GroupPermission);
        IQueryable<MenuItemView> GetProgramsByID(decimal ProgID, bool SysLang);
    }
}
