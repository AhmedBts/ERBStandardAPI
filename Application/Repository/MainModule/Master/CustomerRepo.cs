using Application.Interface.MainModule.Master;
using Application.Interface.SecurityModule.Master;
using Common;
using Domain.Entities.MainModule.Master;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.MainModule.Master
{
    public class CustomerRepo : BaseRepository<Customer>, ICustomer
    {
        public CustomerRepo(HUB_Context context, IUserService userService) : base(context, userService)
        {

        }
        public async Task<string> UploadLogoWithBytes(int customersCode, byte[] formFile)
        {
            string fileExtension = formFile.TryGetExtension();
            string imagePath = null;
            try
            {
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");
                var imagesPath = Path.Combine(rootPath, @"CustomersLogo");
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                var customerLogoFolder = Path.Combine(imagesPath, $"{customersCode}");
                if (!Directory.Exists(customerLogoFolder))
                {
                    Directory.CreateDirectory(customerLogoFolder);
                }
                var fileName = $"customerLogo.{fileExtension ?? "png"}";
                var filePath = Path.Combine(customerLogoFolder, fileName);
                await File.WriteAllBytesAsync(filePath, formFile);
                imagePath = filePath.Substring(rootPath.Length, filePath.Length - rootPath.Length);

            }
            catch (Exception ex)
            {
                imagePath = null;
            }
            return imagePath;
        }


        public async Task<string> UploadLogo(int customersCode, IFormFile formFile)
        {
            string imagePath = null;
            try
            {
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");
                var imagesPath = Path.Combine(rootPath, @"CustomersLogo");
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                var customerLogoFolder = Path.Combine(imagesPath, $"{customersCode}");
                if (!Directory.Exists(customerLogoFolder))
                {
                    Directory.CreateDirectory(customerLogoFolder);
                }
                var fileName = Path.GetFileName(formFile.FileName);
                var filePath = Path.Combine(customerLogoFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                imagePath = filePath.Substring(rootPath.Length, filePath.Length - rootPath.Length);

            }
            catch (Exception ex)
            {
                imagePath = null;
            }
            return imagePath;
        }
        public async Task<Customer> Save(Customer obj, byte[] fileBytes)
        {

            int serial = 1;
            try
            {
                serial = await _context.Customer.MaxAsync(a => a.CustCode);

                serial = serial + 1;

            }
            catch
            {
                serial = 1;

            }
            try
            {
                if (fileBytes != null && fileBytes.Length > 0)
                {
                    obj.Logo = await UploadLogoWithBytes(serial, fileBytes);
                }
                obj.CreateUserId = _userService.GetUserId();
                obj.CreateDateAndTime = DateTime.Now;
                obj.CustCode = (int)serial;

                await _context.Customer.AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj;
            }

            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<Customer> Update(Customer obj, byte[] fileBytes)
        {


         
            try
            {
                var objupdate = await _context.Customer.FindAsync(obj.CustCode);
                objupdate.CustName = obj.CustName;
                objupdate.CustLatName = obj.CustLatName;
                objupdate.CustAddress = obj.CustAddress;
                objupdate.NotActive = obj.NotActive;
                objupdate.CustLatAddress = obj.CustLatAddress;
                objupdate.BasicCurrencyCode = obj.BasicCurrencyCode;
                objupdate.BasicCurrencyCode = obj.BasicCurrencyCode;
                objupdate.Telephone = obj.Telephone;
                objupdate.Fax = obj.Fax;
                objupdate.CountryISO = obj.CountryISO;
                objupdate.Mobile = obj.Mobile;
                objupdate.Email = obj.Email;
                objupdate.Fax = obj.Fax;
                objupdate.ContactPerson = obj.ContactPerson;
                objupdate.ContactPersonEmail = obj.ContactPersonEmail;
                objupdate.TaxId = obj.TaxId;
                objupdate.TaxType = obj.TaxType;
                if (fileBytes != null && fileBytes.Length > 0)
                {
                    objupdate.Logo = await UploadLogoWithBytes(objupdate.CustCode, fileBytes);
                }
                else
                {
                    objupdate.Logo = obj.Logo;
                }
                objupdate.UserId = _userService.GetUserId();
                objupdate.DateAndTime = DateTime.Now;

                _context.Customer.Update(objupdate);
                await _context.SaveChangesAsync();
          
         
                return objupdate;
            }
            catch (Exception ex)
            {
                return null;
            }

               }

    }

}  

