using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Views
{
    public class ActionTypeFilter
    {
        public int? UserId { set; get; }
        public DateTime? Fromdate { set; get; }
        public DateTime? Todate { set; get; }
    }
    public class ActionUserView
    {
        public string? UserName { set; get; }
        public string? Actiontype { set; get; }
        public DateTime? Actiondate  { set; get; }
        public string? IPaddress { set; get; }
    }

}
