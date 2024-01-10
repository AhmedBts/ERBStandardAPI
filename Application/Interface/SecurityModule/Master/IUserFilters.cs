using Domain.Entities.SecurityModule.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.SecurityModule.Master
{
    public interface IUserFilters
    {
        Task<ICollection<User>> GetPlayers();
    }
}
