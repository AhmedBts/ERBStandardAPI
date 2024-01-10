using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.MainModule.Master
{
    public class M_850FieldType : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FieldTypeCode { get; set; }
        public string? FieldTypeAraName { get; set; }
        public string? FieldTypeLatName { get; set; }
    }
}
