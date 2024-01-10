using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class Country: AuditableEntity
    {
        public int CountryCode { get; set; }
        public string CountryName { get; set; } = default!;
        public string PhoneCode { get; set; } = default!;
        public string CountryphoneCode { get; set; } = default!;
        public ICollection<City>? Citys { get; set;} = new List<City>();

    }
}
