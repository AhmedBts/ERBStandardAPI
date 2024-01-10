using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MainModule.Master
{
    public class Branch
    {
        public int BranchCode { get; set; } 
        public int? CompanyCode { get; set; }
        public string? BranchAraName { get; set; } = string.Empty;
        public string? BranchEngName { get; set; }
        public string? BranchLogo { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;
        public string? Telephone { get; set; } = string.Empty;
        public string? Fax { get; set; } = string.Empty;
        public DateTime? OpenDate { get; set; }
        public TimeSpan? workTimeFrom { get; set; }

        public TimeSpan? WorkTimeTo { get; set; }
        public int? LicenseNo { get; set; }
        public int? Manager { get; set; }
        [JsonIgnore]
        public Company? Company { get; set; }



    }
}
