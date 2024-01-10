using Application.Interface;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProgramsRepository :  BaseRepository<Program>, IPrograms
    {
        public ProgramsRepository(HUB_Context context, IUserService userService) : base(context, userService)
        {
            
        }
        public async Task<IQueryable<MenuItemView>> GetDataByParentProgID(decimal ProgID, bool SysLang)
        {
            var x = await (from p in _context.Programs
                           where p.ParentId == ProgID
                           select new MenuItemView
                           {
                               ProgID = p.ProgId,
                               Name = SysLang ? p.ArabicName : p.ArabicName,
                               FormName = p.FormName
                           }).ToListAsync();
            return (IQueryable<MenuItemView>)x;
        }
        public async Task<Program> GetProg(decimal ProgID)
        {
            var x = await _context.Programs.Where(x => x.ProgId == ProgID).FirstOrDefaultAsync();
            return x;
        }
        public async Task<PrgPer> GetProgpermissionperuser(decimal ProgID, int id)
        {
            try
            {
                var x = await (from per in _context.PrgPer
                               where per.UserId == id && per.ProgId == ProgID



                               select per).FirstOrDefaultAsync();
                if (x == null)
                {
                    var useer = await _context.Users.FindAsync(id);
                    x = await (from per in _context.GroupPermission
                               where per.GroupCode == useer.GroupId && per.ProgId == ProgID



                               select new PrgPer
                               {
                                   Delete = per.Delete,
                                   Edit = per.Edit,
                               
                                   Insert = per.Insert,
                                   Print = per.Print,
                                   ProgId = per.ProgId,
                                   Read = per.Read,
                             
                                   UserId = id
                               }).FirstOrDefaultAsync();
                }
                return x;
            }
            catch(Exception ex)
            {
                return null;
            }
         
        }
        public async Task<IQueryable<MenuItemView>> GetProgramsByUserID(int UserId, bool SysLang)
        {
            var x = await (from Pro in _context.Programs
                           join UserPer in _context.PrgPer
                           on Pro.ProgId equals UserPer.ProgId into AllUserPer
                           from UP in AllUserPer.DefaultIfEmpty()
                           where UP.UserId == UserId && Pro.ParentId == 0



                           select new MenuItemView
                           {
                               ProgID = Pro.ProgId,
                               Name = SysLang ? Pro.ArabicName : Pro.ArabicName,
                               FormName = Pro.FormName
                           }).ToListAsync();
            return (IQueryable<MenuItemView>)x;
        }
        public async Task<IQueryable<MenuItemView>> GetProgramsByUserID(int UserId, bool SysLang, decimal ParentID)
        {
            var x = await (from Pro in _context.Programs
                           join UserPer in _context.PrgPer
                           on Pro.ProgId equals UserPer.ProgId into AllUserPer
                           from UP in AllUserPer.DefaultIfEmpty()
                           where UP.UserId == UserId && Pro.ParentId == ParentID
                           && (Pro.FormName == null || Pro.FormName == "")
                           select new MenuItemView
                           {
                               ProgID = Pro.ProgId,
                               Name = SysLang ? Pro.ArabicName : Pro.ArabicName,
                               FormName = Pro.FormName
                           }).ToListAsync();
            return x.AsQueryable();
        }
        public async Task<IQueryable<MenuItemView>> GetPageByUserID(int UserId, bool SysLang, decimal ParentID)
        {
            var x = await (from Pro in _context.Programs
                           join UserPer in _context.PrgPer
                           on Pro.ProgId equals UserPer.ProgId into AllUserPer
                           from UP in AllUserPer.DefaultIfEmpty()
                           where UP.UserId == UserId && Pro.ParentId == ParentID
                           && (Pro.FormName != null && Pro.FormName != "")
                           select new MenuItemView
                           {
                               ProgID = Pro.ProgId,
                               Name = SysLang ? Pro.ArabicName : Pro.ArabicName,
                               FormName = Pro.FormName,
                               URL = Pro.Url
                           }).ToListAsync();
            return x.AsQueryable();
        }

        public async Task<IQueryable<Program>> GetProgramsDetailByGroupId(int GroupId)
        {
            var x = await (from Pro in _context.Programs
                           join Per in _context.GroupPermission
                           on Pro.ProgId equals Per.ProgId
                           where Per.GroupCode == GroupId
                           select new Program
                           {
                               ProgId = Per.ProgId,
                               ParentId = Pro.ParentId,
                               ArabicName = Pro.ArabicName,
                               LatinName = Pro.LatinName,
                               FormName = Pro.FormName,
                               Url = Pro.Url
                           }).ToListAsync();
            return x.AsQueryable();



        }
    }
}
