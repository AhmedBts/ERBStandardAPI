using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class MenuItemView
    {
        public decimal ProgID { get; set; }
        public string Name { get; set; }
        public string FormName { get; set; }
        public string URL { get; set; }
    }
}
