using Domain.Entities.Common;
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
    public class SubLdgType:AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      public int SubLdgTypeCode { get; set; }
      public string? SubLdgTypeAraName { get; set; }
      public string? SubLdgTypeLatName { get; set; }
      public bool? NotActive { get; set; }
        [JsonIgnore]
       public ICollection<M_850DocTypeSubLdgType>? M_850DocTypeSubLdgTypes { set; get; }


    }
}
