using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Sales
{
    public class Order
    {
        public OrderH H { get; set; }
        public List<OrderD> D { get; set; }

        public static implicit operator Order(string v)
        {
            throw new NotImplementedException();
        }
    }
}
