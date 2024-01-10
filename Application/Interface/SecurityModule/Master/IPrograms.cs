
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;


namespace Application.Interface
{
   public interface IPrograms : IBaseRepository<Program>
    {
        Task<IQueryable<MenuItemView>> GetDataByParentProgID(decimal ProgID, bool SysLang);

        Task<IQueryable<Program>> GetProgramsDetailByGroupId(int GroupId);
        Task<IQueryable<MenuItemView>> GetProgramsByUserID(int UserId, bool SysLang);


        Task<IQueryable<MenuItemView>> GetProgramsByUserID(int UserId, bool SysLang, decimal ParentID);

        Task<IQueryable<MenuItemView>> GetPageByUserID(int UserId, bool SysLang, decimal ParentID);
        Task<PrgPer> GetProgpermissionperuser(decimal ProgID, int id);
        Task<Program> GetProg(decimal ProgID);
    }
}
