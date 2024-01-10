using Domain.Entities.MainModule.Master;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Domain.Views;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.MainModule.Master
{
    public interface ICustomer: IBaseRepository<Customer>
    {
        Task<Customer> Update(Customer obj, byte[] fileBytes);
        Task<Customer> Save(Customer obj, byte[] fileBytes);
        Task<string> UploadLogoWithBytes(int customersCode, byte[] formFile);
        Task<string> UploadLogo(int customersCode, IFormFile formFile);
    }
}
