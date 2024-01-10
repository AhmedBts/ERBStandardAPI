using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class PasswordWithOTP : NewPasswordView
    {
        public int VerCode { get; set; }

    }
}
