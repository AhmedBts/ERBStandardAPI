using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class GroupPermission
    {
        public int GroupCode { get; set; }

        public decimal ProgId { get; set; }
        public bool? Insert { get; set; }
        public bool? Edit { get; set; }
        public bool? Read { get; set; }
        public bool? Delete { get; set; }
        public bool? Print { get; set; }
    }
}
