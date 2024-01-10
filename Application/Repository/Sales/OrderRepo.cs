using Application.Interface.MainModule.Master;
using Application.Interface.Sales;
using Domain.Entities.MainModule.Master;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Sales
{
    public class OrderRepo : IOrder
    {
        private readonly HUB_Context _context;
        private readonly IUserService _userService;
        public OrderRepo(HUB_Context context, IUserService userService) 
        {
            _context= context;
            _userService= userService;

        }
        public async Task<string> Delete(int BranchCode, string ProcessType, int Type, int Year, int serial)
        {
           
            try
            {
                var hhh = await _context.OrderH.Where(ordH => ordH.BranchCode == BranchCode &&
                    ordH.ProcessType == ProcessType && ordH.Type == Type && ordH.Year == Year&&ordH.Serial==serial).FirstOrDefaultAsync();
                
                   _context.OrderH.Remove(hhh);
                
                    
                
                var ddd= await _context.OrderD.Where(ordD => ordD.BranchCode == BranchCode &&
                    ordD.ProcessType == ProcessType && ordD.Type == Type && ordD.Year == Year && ordD.Serial == serial).ToListAsync();

                    _context.OrderD.RemoveRange(ddd);
        
                    await _context.SaveChangesAsync();
                return "Deleted";
             
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        public async Task<List<OrderH>> GetAllH(int BranchCode, string ProcessType, int Type, int Year)
        {
            try
            {
                var hhh = await _context.OrderH.Where(ordH => ordH.BranchCode == BranchCode &&
                    ordH.ProcessType == ProcessType && ordH.Type == Type && ordH.Year == Year).ToListAsync();
                return hhh;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<OrderD>> GetOrderDs(int BranchCode, string ProcessType, int Type, int Year, int serial)
        {
            try
            {
                var DDD = await _context.OrderD.Where(ordD => ordD.BranchCode == BranchCode &&
                    ordD.ProcessType == ProcessType && ordD.Type == Type && ordD.Year == Year&& ordD.Serial == serial).ToListAsync();
                return DDD;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<string> Save(OrderH obj)
        {
            try
            {

                int serial = 1;
                try
                {
                    serial = await _context.OrderH.Where(ordH => ordH.BranchCode == obj.BranchCode &&
                        ordH.ProcessType == obj.ProcessType && ordH.Type == obj.Type && ordH.Year == obj.Year).MaxAsync(x => x.Serial);

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
                foreach (var x in obj.orderd)
                {
                    linNum = linNum + 1;
                    x.LineNo = linNum;

                    x.CreateUserid = _userService.GetUserId().ToString();

                    x.CreateDateAndTime = DateTime.Now;

                }
                await _context.OrderH.AddAsync(obj);
                await _context.OrderD.AddRangeAsync(obj.orderd);
                await _context.SaveChangesAsync();

                return "Saved";
            }
            catch (Exception ex)
            {
                _context.OrderH.Remove(obj);
                _context.OrderD.RemoveRange(obj.orderd);
                await _context.SaveChangesAsync();
                return ex.ToString();
            }


        }

        public async Task<string> Update(OrderH obj)
        {
            var upbdatedObj = await _context.OrderH.Where(ordH => ordH.BranchCode == obj.BranchCode &&
                         ordH.ProcessType == obj.ProcessType && ordH.Type == obj.Type && 
                         ordH.Year == obj.Year && ordH.Serial == obj.Serial).FirstOrDefaultAsync();
         
                _context.OrderH.Remove(obj);
           
            var upbdatedDs = await _context.OrderD.Where(ordH => ordH.BranchCode == obj.BranchCode &&
                         ordH.ProcessType == obj.ProcessType && ordH.Type == obj.Type &&
                         ordH.Year == obj.Year && ordH.Serial == obj.Serial).ToListAsync();
     
                _context.OrderD.RemoveRange(obj.orderd);
           
            /////////
            obj.Serial = obj.Serial;
            obj.CreateUserid = obj.CreateUserid;
            obj.CreateDateAndTime = obj.CreateDateAndTime;
            obj.UserId= _userService.GetUserId().ToString();
            obj.DateAndTime= DateTime.Now;

            int linNum = 0;
            foreach (var x in obj.orderd)
            {
                linNum = linNum + 1;
                x.LineNo = linNum;

               x.CreateUserid = obj.CreateUserid;
                x.CreateDateAndTime = obj.CreateDateAndTime;
                x.UserId = _userService.GetUserId().ToString();
                x.DateAndTime = DateTime.Now;

            }
            await _context.OrderH.AddAsync(obj);
            await _context.OrderD.AddRangeAsync(obj.orderd);
            await _context.SaveChangesAsync();

            return "Updated";
        }
            
    ////////
}
    }

