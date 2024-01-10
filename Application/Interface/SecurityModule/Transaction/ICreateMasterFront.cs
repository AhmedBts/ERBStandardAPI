using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.SecurityModule.Transaction
{
    public interface ICreateMasterFront
    {
        Task<Boolean> CreateFormMaster(string TableName);
    }
}
