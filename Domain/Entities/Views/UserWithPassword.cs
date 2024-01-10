using Domain.Entities.SecurityModule.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class UserWithPassword
    {
        public User User { get; set; }
        public string? Password { get; set; }
        public byte[]? Image { get; set; }
    }
    public class staffApproval
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int Id { get; set; }
        public Boolean? Approval { get; set; }
    }
}
