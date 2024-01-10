using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //public static class UploadFile
    //{
    //    public async static Task<string> UploadLogo(int customersCode, IFormFile formFile)
    //    {
    //        string imagePath = null;
    //        try
    //        {
    //            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");
    //            var imagesPath = Path.Combine(rootPath, @"CustomersLogo");
    //            if (!Directory.Exists(imagesPath))
    //            {
    //                Directory.CreateDirectory(imagesPath);
    //            }
    //            var customerLogoFolder = Path.Combine(imagesPath, $"{customersCode}");
    //            if (!Directory.Exists(customerLogoFolder))
    //            {
    //                Directory.CreateDirectory(customerLogoFolder);
    //            }
    //            var fileName = Path.GetFileName(formFile.FileName);
    //            var filePath = Path.Combine(customerLogoFolder, fileName);

    //            using (var fileStream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await formFile.CopyToAsync(fileStream);
    //            }
    //            imagePath = filePath.Substring(rootPath.Length, filePath.Length - rootPath.Length);

    //        }
    //        catch (Exception ex)
    //        {
    //            imagePath = null;
    //        }
    //        return imagePath;
    //    }
    //}
}
