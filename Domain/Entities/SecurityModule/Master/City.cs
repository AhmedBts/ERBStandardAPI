using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class City
    {
        public int CountryCode { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; } = string.Empty;
        public Country? country { get; set; }
    }
}
