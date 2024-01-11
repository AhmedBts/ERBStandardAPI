using Application.Interface.Sales;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Sales
{
    public class TrxRepo : ITrx
    {
        private readonly HUB_Context _context;
        private readonly IUserService _userService;
        public TrxRepo(HUB_Context context, IUserService userService)
        {
            _context = context;
            _userService = userService;

        }
        ////aaaaaa
        public async Task<string> Delete(int BranchCode, int Type, int Year, int serial)
        {

            try
            {
                var hhh = await _context.TrxH.Where(ordH => ordH.BranchCode == BranchCode 
                    && ordH.Type == Type && ordH.Year == Year && ordH.Serial == serial).FirstOrDefaultAsync();

                _context.TrxH.Remove(hhh);



                var ddd = await _context.TrxD.Where(ordD => ordD.BranchCode == BranchCode &&
                   ordD.Type == Type && ordD.Year == Year && ordD.Serial == serial).ToListAsync();

                _context.TrxD.RemoveRange(ddd);

                await _context.SaveChangesAsync();
                return "Deleted";

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public async Task<List<TrxH>> GetAllH(int BranchCode, int Type, int Year)
        {
            try
            {
                var hhh = await _context.TrxH.Where(ordH => ordH.BranchCode == BranchCode &&
                    ordH.Type == Type && ordH.Year == Year).ToListAsync();
                return hhh;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<TrxD>> GetOrderDs(int BranchCode, int Type, int Year, int serial)
        {
            try
            {
                var DDD = await _context.TrxD.Where(ordD => ordD.BranchCode == BranchCode &&
                    ordD.Type == Type && ordD.Year == Year && ordD.Serial == serial).ToListAsync();
                return DDD;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<string> Save(TrxH obj)
        {
            try
            {

                int serial = 1;
                try
                {
                    serial = await _context.TrxH.Where(ordH => ordH.BranchCode == obj.BranchCode &&
                        ordH.Type == obj.Type && ordH.Year == obj.Year).MaxAsync(x => x.Serial);

                    serial = serial + 1;

                }

                catch
                {
                    serial = 1;

                }
                obj.Serial = serial;
                obj.CreateUserid = _userService.GetUserId().ToString();

                obj.CreateDateAndTime = DateTime.Now;

                int linNum = 0;
                foreach (var x in obj.trxds)
                {
                    linNum = linNum + 1;
                    x.LineNum1 = linNum;

                }
                await _context.TrxH.AddAsync(obj);
                await _context.TrxD.AddRangeAsync(obj.trxds);
                await _context.SaveChangesAsync();

                return "Saved";
            }
            catch (Exception ex)
            {
                _context.TrxH.Remove(obj);
                _context.TrxD.RemoveRange(obj.trxds);
                await _context.SaveChangesAsync();
                return ex.ToString();
            }


        }

        public async Task<string> Update(TrxH obj)
        {
            var upbdatedObj = await _context.TrxH.Where(ordH => ordH.BranchCode == obj.BranchCode &&
                         ordH.ProcessType == obj.ProcessType && ordH.Type == obj.Type &&
                         ordH.Year == obj.Year && ordH.Serial == obj.Serial).FirstOrDefaultAsync();

            _context.TrxH.Remove(obj);

            var upbdatedDs = await _context.TrxD.Where(ordH => ordH.BranchCode == obj.BranchCode &&
                         ordH.Type == obj.Type &&
                         ordH.Year == obj.Year && ordH.Serial == obj.Serial).ToListAsync();

            _context.TrxD.RemoveRange(obj.trxds);

            /////////
            obj.Serial = obj.Serial;
            obj.CreateUserid = obj.CreateUserid;
            obj.CreateDateAndTime = obj.CreateDateAndTime;
            obj.UserId = _userService.GetUserId().ToString();
            obj.DateAndTime = DateTime.Now;

            int linNum = 0;
            foreach (var x in obj.trxds)
            {
                linNum = linNum + 1;
                x.LineNum1 = linNum;

            }
            await _context.TrxH.AddAsync(obj);
            await _context.TrxD.AddRangeAsync(obj.trxds);
            await _context.SaveChangesAsync();

            return "Updated";
        }

        ////////
    }
}
