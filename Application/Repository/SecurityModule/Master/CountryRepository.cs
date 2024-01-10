using Application.Interface.SecurityModule.Master;
using Common;
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
    public class CountryRepository : BaseRepository<Country>, ICountry
    {

        public CountryRepository(HUB_Context context, IUserService userService) : base(context, userService)
        {

        }

   public async Task<Country> Save(Country obj)
        {
            int max = 0;
            try
            {
                max = await _context.Countrys.MaxAsync(x => x.CountryCode);
                max = max + 1;
            }
            catch (Exception ex)
            {
                max = 1;
            }
            int i = 0;
            foreach(City city in obj.Citys)
            {
                i = i + 1;
                city.CityCode = i;
            }
            obj.CountryCode = max;
            await _context.Countrys.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;

        }

        public async Task<Country> Update(Country obj)
        {
      
            int i = obj.Citys.Max(x=>x.CityCode);
            foreach (City city in obj.Citys)
            {
                if(city.CityCode==0)
                {
                    i = i + 1;
                    city.CityCode = i;
                }
                
            }
        
             _context.Countrys.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> Delete(int Id ,int Id2)
        {

            try
            {
                var x = await _context.Citys.FindAsync(Id, Id2);
                _context.Citys.Remove(x);
                return true;
            }
            catch (Exception ex) { return false; }
       
        }

    }
}