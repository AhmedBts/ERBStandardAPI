using Application.Filters;

using Application.Repository.SecurityModule.Master;
using Application.Views;
using Domain.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace Hub_API.Controllers.SecurityModule.Master
{
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpGet("Test")]
        public async Task<IActionResult> GetUsers([FromQuery] PageProperties? userParams)
        {

            var apiResponse = new ApiResponse<List<User>>();
            try
            {
                var data =  await _unitOfWork.Users.GetMembersAsync(userParams);
                apiResponse.Success = true;
                apiResponse.Result = data.Pages.ToList();
                apiResponse.pageinfo = data.pageinfo;
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
        [HttpGet("Getall")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<User>>();
            try
            {
                var data = await _unitOfWork.Users.GetAll();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
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

        [HttpGet("Players")]
        public async Task<IActionResult> GetallPlayers()
        {
            var apiResponse = new ApiResponse<List<User>>();
            try
            {
                var data = await _unitOfWork.Users.FindAll(u=>u.UserType == 2);
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
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

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await _unitOfWork.Users.Delete(Id);
                apiResponse.Success = true;
                apiResponse.Result = data;
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
        [HttpGet("Find/{Id}")]
        public async Task<IActionResult> Find([FromRoute] int Id)
        {
            var apiResponse = new ApiResponse<User>();
            try
            {
                var data = await _unitOfWork.Users.GetByIdAsync(Id);
                apiResponse.Success = true;
                apiResponse.Result = data;
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
        [AllowAnonymous]
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] UserWithPassword objs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<User>();
            try
            {
                var data = await _unitOfWork.Users.Save(objs);
                if (data == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Result = data;
                    apiResponse.Message = "0";
                }
                else
                {
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

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserWithPassword obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<User>();
            try
            {
                var data = await _unitOfWork.Users.Update(obj.User, obj.Password,obj.Image);
                apiResponse.Success = true;
                apiResponse.Result = data;
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
       
        [HttpGet("GetPrograms/{id}/{lang}")]
        public async Task<IActionResult> GetPrograms([FromRoute] int id, string lang)
        {

         
            var apiResponse = new ApiResponse<List<Domain.Entities.SecurityModule.Master.Program>>();
            try
            {
                var data = await _unitOfWork.Users.GetPrograms(id, lang);
                apiResponse.Success = true;
                apiResponse.Result = data;
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

        [HttpPut("UpdateUserApproval/{Id}/{Approval}/{groupid}")]
        public async Task<IActionResult> UpdateUserApproval(int Id, int Approval,int groupid)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await _unitOfWork.Users.UpdateUserApproval(Id, Approval, groupid);
                apiResponse.Success = true;
                apiResponse.Result = data;
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

        [HttpGet("UserToApproval")]
        public async Task<IActionResult> UserToApproval()
        {
            var apiResponse = new ApiResponse<List<staffApproval>>();
            try
            {
                var data = await _unitOfWork.Users.UserToApproval();
                apiResponse.Success = true;
                apiResponse.Result = data;
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


        
        [HttpGet("UserLogOut")]
        public async Task<IActionResult> UserLogOut()
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await _unitOfWork.Users.UserLogOut();
                apiResponse.Success = true;
                apiResponse.Result = data;
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
        public async Task<IActionResult> UpdateImage([FromBody]ImageDTO image)
        {
            var apiResponse = new ApiResponse<User>();
            try
            {
                var data = await _unitOfWork.Users.UpdateImage(image);
                apiResponse.Success = true;
                apiResponse.Result = data;
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
        [HttpGet("[action]")]
        public async Task<IActionResult> DeleteImage()
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await _unitOfWork.Users.DeleteImage();
                apiResponse.Success = true;
                apiResponse.Result = data;
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

        [DeactivateEmail]
        [HttpGet("[action]")]
        public async Task<IActionResult> Deactivate()
        {
            var apiResponse = new ApiResponse<int>();
            try
            {
                var data = await _unitOfWork.Users.Deactivate();
                apiResponse.Success = true;
                apiResponse.Result = data;
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


        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordView cpv)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await _unitOfWork.Users.ChangePassword(cpv);
                apiResponse.Success = true;
                apiResponse.Result = data;
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

        [HttpPost("UserLogFilter")]
        public async Task<IActionResult> UserLogFilter(ActionTypeFilter actionTypeFilter)
        {
            var apiResponse = new ApiResponse<List<ActionUserView>>();
            try
            {
                var data = await _unitOfWork.Users.UserLogFilter(actionTypeFilter);
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
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
