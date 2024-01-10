using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class NewPasswordView : UsernameDTO
    {
        public string NewPassword { get; set; }
    }
}
