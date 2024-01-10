using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MainModule.Master
{
    public class M_850DocType:AuditableEntity
    {
        public int Serial { get; set; }
        public int Kind { get; set; }
        public int SubLdgTypeCode { get; set; }
        public int DocTypeCode { get; set; }

        public string? DocTypeAraName { get; set; }
        public string? DocTypeLatName { get; set; }
        public string? Symbol { get; set; }

        public bool? NonActive { get; set; }
        public string? DefaultAdmin { get; set; }
        public string? DefaultRead { get; set; }
        public string? DefaultWrite { get; set; }
        public ICollection<M_850DocTypeSubLdgType>? M_850DocTypeSubLdgTypes { set; get; }


    }
}
