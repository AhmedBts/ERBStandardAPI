using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MainModule.Master
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyCode { get; set; }
        public string? CompanyArName { get; set; }
        public string? CompanyEnName { get; set; }
        [JsonIgnore]
        public ICollection<Branch>? branches { get; set; }
    }
}
