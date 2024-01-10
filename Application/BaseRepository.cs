
using Common;
using Domain.Entities.Common;
using Domain.Entities.SecurityModule.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Persistence;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;


using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Reflection.Metadata;

namespace Application
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        protected HUB_Context _context;
        protected readonly IUserService _userService;
        public BaseRepository(HUB_Context context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> GetAll(string IncludeTable = "")
        {
            if (IncludeTable == "")
            {
                var queryWithout = _context.Set<T>().AsQueryable();

                return await queryWithout.ToListAsync<T>();
            }
            var query = _context.Set<T>().Include(IncludeTable).AsQueryable();

            return await query.ToListAsync<T>();
        }


            public async Task<List<T>> GetAllMultiInclude(params Expression<Func<T, object>>[] includes)
            {
            IQueryable<T> query = _context.Set<T>().AsNoTracking().Include(includes[0]);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return await query.ToListAsync<T>();

            }
        public async Task<IQueryable<T>> FindAll(Expression<Func<T, bool>> criteria,
          params Expression<Func<T, object>>[] IncludeTable)
        {


            IQueryable<T> query = _context.Set<T>().Where(criteria).Include(IncludeTable[0]);
            foreach (var include in IncludeTable.Skip(1))
            {
                query = query.Include(include);
            }
      
            return  query;
        }

        public async Task<T> Save(T entity)
        {
            if (typeof(T).BaseType?.Name == "AuditableEntity")
                _context.Entry(entity).Property("CreateUserId").CurrentValue = _userService.GetUserId();
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> SaveRange(List<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
              await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
             if(typeof(T).BaseType?.Name== "AuditableEntity")
                _context.Entry(entity).Property("UserId").CurrentValue = _userService.GetUserId();
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
          var entity=await  _context.Set<T>().FindAsync(id);
            if(entity == null) return false;
           _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(Expression<Func<T, bool>> Filter)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(Filter);

            if (entity == null) return false;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria,
            string IncludeTable = "")
        {
            if (IncludeTable == "")
            {
                IQueryable<T> query = _context.Set<T>().Where(criteria);
                return await query.ToListAsync();
            }

            IQueryable<T> query1 = _context.Set<T>().AsNoTracking().Include(IncludeTable).Where(criteria).AsQueryable();
            return await query1.ToListAsync();
        }


       


        public async Task<T> Find(Expression<Func<T, bool>> criteria ,string IncludeTable = "")
        {
            if(IncludeTable == "")
            {
                IQueryable<T> query = _context.Set<T>().Where(criteria);
                return await query.FirstOrDefaultAsync();
            }
            else
            {
                IQueryable<T> query = _context.Set<T>().Include(IncludeTable).Where(criteria);
                return await query.FirstOrDefaultAsync();
            }
         
        }
        public async Task<T> Save(T entity, Func<T, int>? columnSelector, string key
            , Expression<Func<T, bool>>? criteria = null)
        {

            if (columnSelector != null)
            {
                var keyValue = GetMaxPK(columnSelector, criteria);
                _context.Entry(entity).Property(key).CurrentValue
                                           = keyValue;

            }

            if (typeof(T).BaseType?.Name == "AuditableEntity")
                _context.Entry(entity).Property("CreateUserId").CurrentValue = _userService.GetUserId();
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public int GetMaxPK(Func<T, int> columnSelector, Expression<Func<T, bool>> criteria)
        {
            try
            {
                var GetMaxId = criteria == null ? _context.Set<T>().Max(columnSelector) : _context.Set<T>().Where(criteria).Max(columnSelector);
                return GetMaxId + 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public async Task<List<dynamic>> GetAllSalesMaster(string funName, Expression<Func<T, bool>> criteria = null)
        {

            try
            {
                dynamic data = ADOData.CollectionFromSql(_context, $@"select * from {funName}").ToList();
                return data;
            }
            catch (Exception ex)
            {

                return null;
            }
            
      
        }

        public async Task<ItemViewDataResult> GetItemData( ItemViewData data)
        {
            ItemViewDataResult result = new ItemViewDataResult();
                string SQL = @"SELECT BranchCode" + (data.storeCode != "" ? ",StoreName, StoreCode" : "")
            + @", ItemCode, ItemName, Round(SUM(Balance),6) AS Balance, SUM(SumOfInQty) AS SumOfInQty, SUM(SumOfoutQty) AS SumOfoutQty, 
                          GroupMainCode, GroupSubCode, UOMCode
                          FROM (
                             SELECT dbo.StoreCode.StoreName, dbo.TrxH.StoreCode, dbo.TrxD.ItemCode, Items.ItemName, dbo.TrxH.BranchCode, dbo.TrxH.Date, 
                         Round( SUM(CASE WHEN dbo.TrxD.Type < 100 THEN ISNULL(dbo.TrxD.Qty, 0) ELSE - ISNULL(dbo.TrxD.Qty, 0) END),6) AS Balance, 
                          SUM(CASE WHEN dbo.TrxD.Type < 100 THEN ISNULL(dbo.TrxD.Qty, 0) ELSE 0 END) AS SumOfInQty, 
                          SUM(CASE WHEN dbo.TrxD.Type > 100 THEN ISNULL(dbo.TrxD.Qty, 0) ELSE 0 END) AS SumOfoutQty, Items.GroupMainCode, 
                          Items.GroupSubCode, Items.UOMCode
                          FROM dbo.TrxH INNER JOIN
                          dbo.TrxD ON dbo.TrxH.BranchCode = dbo.TrxD.BranchCode AND dbo.TrxH.Type = dbo.TrxD.Type AND dbo.TrxH.Year = dbo.TrxD.Year AND 
                          dbo.TrxH.Serial = dbo.TrxD.Serial INNER JOIN
                          dbo.StoreCode ON dbo.TrxH.BranchCode = dbo.StoreCode.BranchCode AND dbo.TrxH.StoreCode = dbo.StoreCode.StoreCode INNER JOIN
                          Items ON dbo.TrxD.ItemCode = Items.ItemCode
                          WHERE (dbo.TrxH.Date <= '" +data.trxDate?.ToString("yyyy-MM-dd") + @"')
                          AND (Items.ItemServiceProd <> 2 and Items.ItemServiceProd <> 5  and Items.ItemServiceProd <> 6)
                          GROUP BY dbo.StoreCode.StoreName, dbo.TrxH.StoreCode, dbo.TrxD.ItemCode, dbo.TrxH.BranchCode, dbo.TrxH.Date, Items.ItemName, 
                          Items.ItemLatName, Items.GroupMainCode,Items.GroupSubCode,Items.UOMCode) AS Main
                          where BranchCode = " + data.branchCode
                  + (data.storeCode != "" ? " AND StoreCode = " + data.storeCode : "")
                  + " AND LTRIM(RTRIM(ItemCode)) = '" + data.itemCode?.Trim() + @"'
                            GROUP BY StoreName, StoreCode, ItemCode, ItemName, BranchCode, GroupMainCode, GroupSubCode, UOMCode
                            order by BranchCode" + (data.storeCode != "" ? ",StoreCode" : "") + @",ItemCode";
                var Dt = ADOData.CollectionFromSqlDT(_context, SQL);
          if(Dt != null&&Dt.Rows.Count>0) {
                result.balance = Dt.Rows[0]["Balance"].ToString();
            }
          var price=GetPrice(data);
            result.price = price;
            return result;
        }
        public  string GetPrice(ItemViewData data) {
        
              
                    String SQL = "";
                   
                    SQL = @"  Select SalesPrice From ItemSalesPrices
                                                         INNER JOIN
                                     dbo.Customer ON dbo.ItemSalesPrices.PriceCategoryCode = dbo.Customer.PriceCategory                      
                                                        Where BranchCode = " + data.branchCode
                                    + @" And LTRIM(RTRIM(ItemCode)) = '" + data.branchCode.Trim() + "'"
                                    + (data.targetCode != "" ? " AND dbo.Customer.CustCode = " + data.targetCode : "")
                                + @" And CONVERT(varchar, StartDate , 111) + ' ' + CONVERT(varchar, Time) = 
                                                        (
                                                        Select Max(CONVERT(varchar, StartDate , 111) + ' ' + CONVERT(varchar, Time)) StartDateTime
                                                        From dbo.ItemSalesPrices 
 INNER JOIN dbo.Customer ON dbo.ItemSalesPrices.PriceCategoryCode = dbo.Customer.PriceCategory 
                                                        Where BranchCode = " + data.branchCode
                                + @" And LTRIM(RTRIM(ItemCode)) = '" + data.itemCode.Trim() + "'"
                                + @"
And CONVERT(varchar, StartDate , 111) + ' ' + CONVERT(varchar, Time) <= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                               + "' " + (data.targetCode != "" ? " AND dbo.Customer.CustCode = " + data.targetCode : "") + @")";

                 var   DisplaySalesPrice = ADOData.CollectionFromSqlDT(_context, SQL);

            if (DisplaySalesPrice != null && DisplaySalesPrice.Rows.Count > 0)
            {
                var xxxx = Convert.ToDecimal(DisplaySalesPrice.Rows[0]["SalesPrice"]) * 1;
                return xxxx.ToString()
                          ;
                // Convert.ToDecimal(Grid["UOMConvFactor", Grid.CurrentCell.RowIndex].Value != null && Grid["UOMConvFactor", Grid.CurrentCell.RowIndex].Value.ToString() != ""
                //&& Convert.ToDecimal(Grid["UOMConvFactor", Grid.CurrentCell.RowIndex].Value.ToString()) > 0 ?
                //Convert.ToDecimal(Grid["UOMConvFactor", Grid.CurrentCell.RowIndex].Value.ToString()) : Convert.ToDecimal(1));

            }
            else return "0";


        }
    }
}
