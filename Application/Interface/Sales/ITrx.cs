using Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Sales
{
    public interface ITrx
    {
        Task<string> Save(TrxH obj);
        Task<string> Update(TrxH obj);

        Task<List<TrxH>> GetAllH(int BranchCode, int Type, int Year);
        Task<List<TrxD>> GetOrderDs(int BranchCode, int Type, int Year, int serial);
        Task<string> Delete(int BranchCode, int Type, int Year, int serial);
    }
}
