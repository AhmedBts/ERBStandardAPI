using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.SecurityModule.Master
{
    public interface IAuth
    {
         Task<VUserLogin> loginuser(VUser vUser);
        Task<User> SaveClient(ClientUser obj);
        /// <summary>
        /// Updates password after confirming that the old password is correct.
        /// </summary>
        /// <param name="updatePassword">carries object consists of old password, new password and email/username</param>
        /// <returns>returns a message that represents the result and status of operation. </returns>
         Task<ResMessage> ResetPassword(UpdatePasswordView updatePassword);
        /// <summary>
        /// send Verification Code to Email to confirm user email is correct.
        /// </summary>
        /// <param name="username">carries user email</param>
        /// <returns>returns a message that represents the result and status of operation. </returns>
        Task<ResMessage> ForgotPasswordMail(string username);
        /// <summary>
        /// Updates password after confirming that the verification code ,which is sent by email, is correct.
        /// </summary>
        /// <param name="passwordWithOTP">carries object consists of verification code, new password and email/username</param>
        /// <returns>returns a message that represents the result and status of operation. </returns>
        Task<ResMessage> UpdatePasswordWithOTP(PasswordWithOTP passwordWithOTP);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passowrds"></param>
        /// <returns></returns>
        Task<ResMessage> CreateNewPasswrod(NewPasswordView passowrds);
    }
}
