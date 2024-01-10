using Domain.Entities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MainModule.Master
{

    public class M_850DocTypeSubLdgType:AuditableEntity
    {
        public int Serial { get; set; }
        public int Kind { get; set; }
        public int DocTypeCode { get; set; }
        public int SubLdgTypeCode { get; set; }
        [JsonIgnore]
        public SubLdgType? subLdgType { get; set; }
        [JsonIgnore]
        public M_850DocType? m_850DocType { get; set; }



    }
}
