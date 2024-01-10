
using Application.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers.Extensions
{
    public static class PagersExt
    {
       public async static Task<Pager<T>> Pagination<T>(this IQueryable<T> query,int currentpage =0, int pageSize =100) where T : class
        {
           var countitem= query.Count();
            Pager<T> pager = new Pager<T>() {
                    pageinfo =new BasePage { CurrentPage = currentpage,
                        PageSize =  pageSize==0?100: pageSize,
                        TotalItems=countitem
                    },
                };



            query = query.Skip(pager.pageinfo.CurrentPage * (int)pager.pageinfo.PageSize);
            if (pager.pageinfo.PageSize > 0)
            {
                query = query.Take((int)pager.pageinfo.PageSize);
            }

            pager.Pages = await query.ToListAsync();

            return pager;
            
           
        }

    }
}
