using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAll(string IncludeTable = "");
        Task<bool> Delete(int id);
        Task<T> Save(T entity);
        Task<List<T>> SaveRange(List<T> entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Expression<Func<T, bool>> Filter);
        Task<T> Find(Expression<Func<T, bool>> criteria,string IncludeTable = "");
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria, string IncludeTable = "");

     
        Task<T> Save(T entity, Func<T, int>? columnSelector, string key
             , Expression<Func<T, bool>> criteria = null);
        Task<List<T>> GetAllMultiInclude(params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> FindAll(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);

        Task<List<dynamic>> GetAllSalesMaster(string funName, Expression<Func<T, bool>> criteria=null);
        Task<ItemViewDataResult> GetItemData(ItemViewData data);

    }
}
