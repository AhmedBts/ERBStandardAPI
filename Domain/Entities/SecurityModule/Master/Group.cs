using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class Group : AuditableEntity
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = default!;
        public string GroupLatName { get; set; } = default!;
        public virtual ICollection<User>? Users { get; set; }
    }
}
