using Application.Interface.SecurityModule.Master;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.SecurityModule.Master
{
    public class GroupPermissionRepository : IGroupPermission
    {
        readonly HUB_Context db;


        public GroupPermissionRepository(HUB_Context db)
        {
            this.db = db;
        }
        public IQueryable<MenuItemView> GetProgramsByGroup(int GroupCode, bool SysLang)
        {
            var x = (from GPro in db.Programs
                     join GroupPer in db.GroupPermission
                     on GPro.ProgId equals GroupPer.ProgId
                     where GroupPer.GroupCode == GroupCode && GPro.ParentId == 0

                     select new MenuItemView
                     {
                         ProgID = GPro.ProgId,
                         Name = SysLang ? GPro.ArabicName : GPro.LatinName,
                         FormName = GPro.FormName
                     });
            return x;
        }

        public IQueryable<MenuItemView> GetProgramsByGroup(int GroupCode, bool SysLang, decimal ParentID, bool PageYN = false)
        {
            var x = (from GPro in db.Programs
                     join GroupPer in db.GroupPermission
                     on GPro.ProgId equals GroupPer.ProgId
                     where GroupPer.GroupCode == GroupCode && GPro.ParentId == ParentID
                      && (PageYN == true ? (GPro.FormName != null || GPro.FormName != "") : (GPro.FormName == null || GPro.FormName == ""))


                     select new MenuItemView
                     {
                         ProgID = GPro.ProgId,
                         Name = SysLang ? GPro.ArabicName : GPro.LatinName,
                         FormName = GPro.FormName,
                         URL = GPro.Url
                     });
            return x;
        }

        public IQueryable<MenuItemView> GetProgramsByID(decimal ProgID, bool SysLang)
        {
            var x = (from GPro in db.Programs
                     where GPro.ProgId == ProgID
                     select new MenuItemView
                     {
                         ProgID = GPro.ParentId.Value,
                         Name = SysLang ? GPro.ArabicName : GPro.LatinName,
                         FormName = GPro.FormName,
                         URL = GPro.Url
                     });
            return x;
        }

        public async Task<List<UserPermissionDetailView>> GetUserPermissionDetails(int GroupCode)
        {
            var x = await (from GPro in db.Programs
                           join GroupPer in db.GroupPermission
                           on GPro.ProgId equals GroupPer.ProgId
                           where GroupPer.GroupCode == GroupCode
                           select new UserPermissionDetailView
                           {
                               UserId = GroupCode,
                               ProgId = GPro.ProgId,
                           }

                                 ).ToListAsync();

            return x;
        }

        public async Task<List<UserPermissionDetailView>> SaveGroupPermission(List<UserPermissionDetailView>
            GroupPermission)
        {
            try
            {
                List<GroupPermission> xobj = await db.GroupPermission.Where(
                    t => t.GroupCode == GroupPermission[0].GroupCode
                    //&& t.ProgId == GroupPermission[0].ProgId
                    ).ToListAsync();
                var groupsave = xobj.Where(item =>

          GroupPermission.Any(category => category.ProgId.Equals(item.ProgId))).ToList();

                db.GroupPermission.RemoveRange(groupsave);
                await db.SaveChangesAsync();
                GroupPermission x2 = new GroupPermission();
                var listtosave = GroupPermission.Where(x => x.Read == true || x.Insert == true || x.Print == true
                || x.Edit == true || x.Delete == true).ToList();
                foreach (UserPermissionDetailView newList in listtosave)
                {
                    if (newList.Insert == true || newList.Delete == true || newList.Edit == true
                       || newList.Print == true || newList.Read == true)
                    {
                        x2.GroupCode = newList.GroupCode;

                        x2.ProgId = newList.ProgId;
                        x2.Insert = newList.Insert;
                        x2.Edit = newList.Edit;
                        x2.Read = newList.Read;
                        x2.Delete = newList.Delete;
                        x2.Print = newList.Print;

                        await db.GroupPermission.AddRangeAsync(x2);

                        x2 = new GroupPermission();
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
        public async Task<List<UserPermissionDetailView>> showGroupPermission(int GroupCode)
        {
            try
            {
                List<Program> programs = await db.Programs.ToListAsync();
                List<GroupPermission> GPList = new List<GroupPermission>();
                GPList = await db.GroupPermission.Where(x => x.GroupCode == GroupCode).ToListAsync();


                List<UserPermissionDetailView> result = GPList.Where(item =>
item.GroupCode == GroupCode &&
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

        [Obsolete]
        public async Task<List<UserPermissionDetailView>> showGroupPermissionwithparentid(int GroupCode, int Progid)
        {
            try
            {
                List<Program> programs = await db.Programs.ToListAsync();
                List<GroupPermission> GPList = new List<GroupPermission>();

                GPList = await db.GroupPermission.Where(x => x.GroupCode == GroupCode).ToListAsync();


                List<UserPermissionDetailView> result = GPList.Where(item =>
item.GroupCode == GroupCode &&
    programs.Any(category => category.ProgId.Equals(item.ProgId))).Select(x => new UserPermissionDetailView
    {
        ProgId = x.ProgId,
        ArabicName = programs.Where(y => y.ProgId == x.ProgId).Select(x => x.ArabicName).FirstOrDefault(),
        Delete = x.Delete,
        Edit = x.Edit,

        GroupCode = GroupCode,
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

     GroupCode = GroupCode,
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