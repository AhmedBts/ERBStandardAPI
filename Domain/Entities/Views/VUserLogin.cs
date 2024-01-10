using Domain.Entities.SecurityModule.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class VUserLogin
    {
        public User User { get; set; }

        public string XToken { get; set; }
    }
}
