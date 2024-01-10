using Application.Interface.SecurityModule.Master;
using Application.Views;
using Common;
using Domain.Entities.SecurityModule.Master;
using Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Application.Repository.SecurityModule.Master
{
    public class AuthRepository : IAuth
    {
        protected HUB_Context _Context;
        protected readonly IUserService _userService;
        public AuthRepository(HUB_Context context, IUserService userService)
        {
            _Context = context;
            _userService = userService;
        }
        public async Task<User> SaveClient(ClientUser obj)
        {
            var exist = await _Context.Users.Where(x => x.UserName == obj.User.UserName ||
           x.Email == obj.User.Email).FirstOrDefaultAsync();
            if (exist != null)
            {
                return null;
            }
            obj.User.UserType = 2;
            obj.User.Approval = true;
            await _Context.Users.AddAsync(obj.User);
            await _Context.SaveChangesAsync();
            if (obj.Image != null)
            {
                obj.User.PhotoUserPath = await SecurityLogic.Instance().UploadLogoWithBytes(obj.User.Id, obj.Image);
            }
            _Context.Users.Update(obj.User);
            UserLog userLog = new UserLog();
            userLog.UserId = obj.User.Id;
            userLog.IPaddress = _userService.GetUserIdaddress();
            userLog.CreatedAt = DateTime.Now;
            userLog.ActionType = 1;
          
            await _Context.SaveChangesAsync();
            return obj.User;
        }
        public async Task<VUserLogin> loginuser(VUser vUser)
        {
            try
            {
                UserLog userLog = new UserLog();
                var x = await _Context.Users.Where(x => (x.UserName == vUser.username
                || x.Email == vUser.username) ).
                Select(u=> new VUserLogin
                {
                    User=u,
                    XToken = ""
                }).FirstOrDefaultAsync();
                if (x == null)
                {
          
                    return null;
                }
                if(x.User.Approval==null|| x.User.Approval ==false)
                {
                    return x;
                }

                if (!SecurityLogic.Instance().verfiypasswordhash(vUser.password, x.User.PasswordSolt, x.User.PasswordHash))
                {
                   
                    userLog.UserId = x.User.Id;
                    userLog.CreatedAt = DateTime.Now;
                    userLog.ActionType = 3;
                    userLog.IPaddress = _userService.GetUserIdaddress();
                    _Context.UsersLog.Add(userLog);
                    return null;
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AFego$#*&!@UYREpopop*&!Bts11111GSWInvoice@2021whm#@"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                                       claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, x.User.Id.ToString()),
                        new Claim(ClaimTypes.Role, x.User.GroupId.ToString()),
                        new Claim(ClaimTypes.GroupSid, x.User.UserName),
                        new Claim(type:"Country", x.User.CountryCode!.ToString()),
                        new Claim(type:"Type",value:x.User.UserType!.ToString())

                    },

                    expires: DateTime.Now.AddDays(15),
                    signingCredentials: signinCredentials
    
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                x.XToken = tokenString;
                userLog.IPaddress = _userService.GetUserIdaddress();
                userLog.UserId = x.User.Id;
                userLog.CreatedAt = DateTime.Now;
                userLog.ActionType = 4;
                _Context.UsersLog.Add(userLog);
                return x;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<ResMessage> ResetPassword(UpdatePasswordView updatePassword)
        {
            ResMessage resMessage = new ResMessage();

            var user = await _Context.Users.FirstOrDefaultAsync(x => (x.UserName == updatePassword.UserName
            || x.Email == updatePassword.UserName) && x.Approval == true);
            if (user == null)
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "User isn't approved or registered";
                return resMessage;
            }
            if (!SecurityLogic.Instance().verfiypasswordhash(updatePassword.OldPassword, user.PasswordSolt, user.PasswordHash))
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "Old password is wrong";
                return resMessage;
            }
            if (!updatePassword.NewPassword.ValidatePassword())
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "Password must Include both lower case and upper case characters, Include at least one number or symbol and be at least 8  characters long";
                return resMessage;
            }

            SecurityLogic.Instance().CreatePassword(updatePassword.NewPassword, out var PasswordHash, out var PasswordSolt);
            user.PasswordHash = PasswordHash;
            user.PasswordSolt = PasswordSolt;
            _Context.Users.Update(user);
            await _Context.SaveChangesAsync();
            resMessage.IsSuccess = true;
            resMessage.Message = "Password is updated successfully";
            return resMessage;
        }

        public async Task<ResMessage> ForgotPasswordMail(string username)
        {
            ResMessage resMessage = new ResMessage();
            try
            {
                var user = await _Context.Users.FirstOrDefaultAsync(x => (x.UserName == username
        || x.Email == username) && x.Approval == true);
                if (user == null)
                {
                    resMessage.IsSuccess = false;
                    resMessage.Message = "User isn't approved or registered";
                    return resMessage;
                }

                #region Generate Ver Code
                //Random rand = new();
                //var userCodes = _Context.VerificationCodes.Where(vc => vc.UserId == user.Id).Select(vc => vc.Code).ToList();
                //int result = rand.Next(100000, 999999);
                //while (userCodes.Contains(result))
                //{
                //    result = rand.Next(100000, 999999);
                //}
                VerificationCode verCode = new VerificationCode();
                verCode.UserId = user.Id;
                verCode.Code = _Context.VerificationCodes.GenerateCodes(vc=> vc.UserId == user.Id);
                #endregion

                #region Send E-mail
                var generalSetup = _Context.GeneralSetups.FirstOrDefault();
                MailMessage mailMessage = new MailMessage();
                var Body = @$"<p>Verify your email, {user.Name}.</p>
                                 <br/>
                                 <p>Enter this code in your browser to verify your email and create your new password</p>
                                    <b style='color:#002060'>{verCode.Code}</b>
                                <br/>
                                  <p>if you didn't request a code, you can safely ignore this email.</p>
                                    <p>Best regards,</p>                               
                                    <p>Best Top team.</p>";
                mailMessage.SendSMTP(generalSetup!,subject: "Verification Code"
                    ,mailAddresses: new string[] {user.Email!},
                    body: Body);
                #endregion
                _Context.VerificationCodes.Add(verCode);
                _Context.SaveChanges();
                resMessage.IsSuccess = true;
                resMessage.Message = "Email is sent successfully";

            }
            catch (Exception)
            {
                resMessage.IsSuccess = true;
                resMessage.Message = "Email isn't sent. make sure your email address is valid";

            }
            return resMessage;
        }

        public async Task<ResMessage> UpdatePasswordWithOTP(PasswordWithOTP passwordWithOTP)
        {
            ResMessage resMessage = new ResMessage();

            var user = await _Context.Users.Include(u=>u.VerificationCodes).FirstOrDefaultAsync(x => (x.UserName == passwordWithOTP.UserName
            || x.Email == passwordWithOTP.UserName) && x.Approval == true);
            if (user == null)
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "User isn't approved or registered";
                return resMessage;
            }
            var validCode = user.VerificationCodes.FirstOrDefault(vc => vc.Code == passwordWithOTP.VerCode
            && vc.UserId == user.Id && !vc.IsUsed);
            if (validCode == null)
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "Verification Code is wrong";
                return resMessage;
            }
            if (!passwordWithOTP.NewPassword.ValidatePassword())
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "Password must Include both lower case and upper case characters, Include at least one number or symbol and be at least 8  characters long";
                return resMessage;
            }

            SecurityLogic.Instance().CreatePassword(passwordWithOTP.NewPassword, out var PasswordHash, out var PasswordSolt);
            user.PasswordHash = PasswordHash;
            user.PasswordSolt = PasswordSolt;
            _Context.Users.Update(user);
            validCode.IsUsed = true;
            _Context.VerificationCodes.Update(validCode);
            await _Context.SaveChangesAsync();
            resMessage.IsSuccess = true;
            resMessage.Message = "Password is updated successfully";
            return resMessage;
        }
        

        public async Task<ResMessage> CreateNewPasswrod(NewPasswordView passowrds)
        {
            ResMessage resMessage = new ResMessage();
            var userVal = SecurityLogic.Instance().Decrypt(passowrds.UserName);
            var user = await _Context.Users.FirstOrDefaultAsync(x => (x.UserName == userVal
            || x.Email == userVal));

            if (user == null)
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "User isn't registered";
                return resMessage;
            }
            if (user.PasswordHash != null && user.PasswordSolt != null)
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "link is expired";
                return resMessage;
            }
            if (!passowrds.NewPassword.ValidatePassword())
            {
                resMessage.IsSuccess = false;
                resMessage.Message = "Password must Include both lower case and upper case characters, Include at least one number or symbol and be at least 8  characters long";
                return resMessage;
            }

            SecurityLogic.Instance().CreatePassword(passowrds.NewPassword, out var PasswordHash, out var PasswordSolt);
            user.PasswordHash = PasswordHash;
            user.PasswordSolt = PasswordSolt;
            _Context.Users.Update(user);
            await _Context.SaveChangesAsync();
            resMessage.IsSuccess = true;
            resMessage.Message = "Password is updated successfully";
            return resMessage;



        }

    }
}
