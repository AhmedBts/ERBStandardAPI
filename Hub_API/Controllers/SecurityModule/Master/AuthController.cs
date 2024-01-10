using Application.Filters;
using Domain.Entities.Views;

namespace Hub_API.Controllers.SecurityModule.Master
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthController : ControllerBase
    {
        IAuth _IAuthRepository;
        public AuthController(IAuth IAuthRepository)
        {
            _IAuthRepository = IAuthRepository;
        }
        [SendClientEmail]
        [HttpPost("SaveClient")]
        public async Task<IActionResult> SaveClient(ClientUser obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<User>();
            try
            {
                var data = await _IAuthRepository.SaveClient(obj);
                if(data == null) {
                    apiResponse.Success = false;
                    apiResponse.Message = "User or e-mail already used";
                }
                else {
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            return Ok(apiResponse);
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewPasswrod([FromBody]NewPasswordView passowrds)
        {
            var apiResponse = new ApiResponse<string>();
            var result = await _IAuthRepository.CreateNewPasswrod(passowrds);
            apiResponse.Success = result.IsSuccess;
            apiResponse.Message = result.Message;
            apiResponse.Result = passowrds.UserName;
            return Ok(apiResponse);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] UpdatePasswordView updatePasswordView)
        {
            var apiResponse = new ApiResponse<string>();
            var result = await _IAuthRepository.ResetPassword(updatePasswordView);
            apiResponse.Success = result.IsSuccess;
            apiResponse.Message = result.Message;
            apiResponse.Result = updatePasswordView.UserName;

            return Ok(apiResponse);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPasswordMail(UsernameDTO username)
        {
            var apiResponse = new ApiResponse<string>();
            var result = await _IAuthRepository.ForgotPasswordMail(username.UserName);
            apiResponse.Success = result.IsSuccess;
            apiResponse.Message = result.Message;
            apiResponse.Result = username.UserName;
            return Ok(apiResponse);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePasswordWithOTP([FromBody]PasswordWithOTP passwordWithOTP)
        {
            var apiResponse = new ApiResponse<string>();
            var result = await _IAuthRepository.UpdatePasswordWithOTP(passwordWithOTP);
            apiResponse.Success = result.IsSuccess;
            apiResponse.Message = result.Message;
            apiResponse.Result = passwordWithOTP.UserName;
            return Ok(apiResponse);
        }


        [AllowAnonymous]
        [HttpPost("loginuser")]
        public async Task<IActionResult> login([FromBody] VUser dtoUser)
        {
            var apiResponse = new ApiResponse<VUserLogin>();
            try
            {
                var data = await _IAuthRepository.loginuser(dtoUser);
                apiResponse.Success = true;
                apiResponse.Result = data;
                    if (data!=null) {
                    if (!(data.User.Approval ?? false )) {
                        apiResponse.Success = false;
                        apiResponse.Message = "The admin haven't approved your user access yet.";

                    } 
                }
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            return Ok(apiResponse);

        }
    }
}
