namespace Hub_API.Controllers.SecurityModule.Master
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPermissionController : ControllerBase
    {

        private readonly IGroupPermission _GroupPermissionRepository;

        public GroupPermissionController(IGroupPermission groupPermissionRepository)
        {
            _GroupPermissionRepository = groupPermissionRepository;
        }
        [HttpGet("GetUserPermission/{GroupID}")]
        public async Task<IActionResult> GetUserPermission([FromRoute] int GroupID)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.GetUserPermissionDetails(GroupID);
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

        [HttpGet("showGroupPermission/{GroupID}")]
        public async Task<IActionResult> showGroupPermission([FromRoute] int GroupID)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.showGroupPermission(GroupID);
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
        [HttpGet("showGroupPermissionwithparentid/{GroupID}/{Progid}")]
        public async Task<IActionResult> showGroupPermissionwithparentid([FromRoute] int GroupID, int Progid)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.showGroupPermissionwithparentid(GroupID, Progid);
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


        [HttpPost("SaveGroupPermission")]
        public async Task<IActionResult> SaveGroupPermission([FromBody] List<UserPermissionDetailView> GroupID)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.SaveGroupPermission(GroupID);
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
    }
}