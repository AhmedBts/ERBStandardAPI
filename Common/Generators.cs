using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Generators
    {
        public static int GenerateCodes<T>(this DbSet<T> dbSet,Func<T,bool> criteria,string field = "Code", int from = 100000,int to= 999999) where T :class
        {
            Random rand = new();
            var codes = dbSet.Where(criteria).Select(obj => obj.GetType().GetProperty(field).GetValue(obj)).ToList();
            resultsReplay:
            
            if(codes.Count >= (to - from) )
            {
                from = from * 100;
                to = (to * 100) + 99;
                goto resultsReplay;
            }    
            int result = rand.Next(from, to);
            while (codes.Contains(result))
            {
                result = rand.Next(from, to);
            }
            return result;
        }
    }
}
