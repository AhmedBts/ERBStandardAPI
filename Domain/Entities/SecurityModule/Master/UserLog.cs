using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.SecurityModule.Master
{
    public class UserLog
    {
        public int Id { get; set; }
        public int UserId  { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ActionType { get; set; }
        public string? IPaddress { set; get; }

    }
}
