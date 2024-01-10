using Domain.Entities.SecurityModule.Master;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.SecurityModule.Master
{
    public class CityReporitory : BaseRepository<City>
    {
        public CityReporitory(HUB_Context context, IUserService userService) : base(context, userService)
        {
        }
    }
}
