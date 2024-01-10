using Application.Helpers;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class Pager<T>  where T : class
    {
        public BasePage? pageinfo { get; set; }
        public ICollection<T>? Pages { get; set; }
    }
}
