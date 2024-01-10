using Domain.Entities.MainModule.Master;
using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Sales
{
    public interface IOrder
    {
        Task<string> Save(OrderH obj );
        Task<string> Update(OrderH obj);
       
        Task<List<OrderH>> GetAllH(int BranchCode, string ProcessType, int Type, int Year);
        Task<List<OrderD>> GetOrderDs(int BranchCode, string ProcessType, int Type, int Year,int serial);
        Task<string> Delete(int BranchCode, string ProcessType, int Type, int Year, int serial);
    }
}
