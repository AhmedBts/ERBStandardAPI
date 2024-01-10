using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class UpdatePasswordView : NewPasswordView
    {
        public string OldPassword { get; set; }
    }
}
