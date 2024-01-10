using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.SecurityModule.Master
{
    public interface ICountry : IBaseRepository<Country>
    {
         Task<Country> Save(Country obj);
         Task<Country> Update(Country obj);
        Task<bool> Delete(int Id, int Id2);




    }
}
