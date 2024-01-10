using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Views
{
    public class ChangePasswordView
    {
        public int UserCode { set; get; }
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
    }
}
