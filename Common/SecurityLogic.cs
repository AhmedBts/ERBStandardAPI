

using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public  class SecurityLogic
    {
        public string encryptingKey = "DEooW1234@wqq!qq";
        static readonly char[] padding = { '=' };
        public static SecurityLogic _SecurityLogic = null;
        private SecurityLogic()
        {

        }
        public static SecurityLogic Instance()
        {
            if (_SecurityLogic == null)
            {

                _SecurityLogic = new SecurityLogic();
                return _SecurityLogic;
            }

            else
                return _SecurityLogic;
        }
        public  bool verfiypasswordhash(string password, byte[] passwordSolt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSolt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
        public  void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSolt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSolt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptingKey);
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array).TrimEnd(padding).Replace('+', '-').Replace('/', '_');
        }


        public string Decrypt(string cipherText)
        {
            string incoming = cipherText
    .Replace('_', '/').Replace('-', '+');
            switch (cipherText.Length % 4)
            {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }
            byte[] iv = new byte[16];
            byte[] cipherBytes = Convert.FromBase64String(incoming);
            using (Aes encryptor = Aes.Create())
            {
                encryptor.Key = Encoding.UTF8.GetBytes(encryptingKey);
                encryptor.IV = iv;
                encryptor.Padding = PaddingMode.PKCS7;
                encryptor.Mode = CipherMode.CBC;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return cipherText;

        }

        public  async Task<string> UploadLogoWithBytes(int Id, byte[] formFile,string PathUrl= "Images")
        {
            string fileExtension = formFile.TryGetExtension();
            string imagePath = null;
            try
            {
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");
                var imagesPath = Path.Combine(rootPath, PathUrl);
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                var customerLogoFolder = Path.Combine(imagesPath, $"{Id}");
                if (!Directory.Exists(customerLogoFolder))
                {
                    Directory.CreateDirectory(customerLogoFolder);
                }
                else
                {
                    foreach (FileInfo file in new DirectoryInfo(customerLogoFolder).GetFiles())
                    {
                        file.Delete();
                    }
                }
             
                var fileName = $"Images.{fileExtension ?? "png"}";
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
    }
}
