namespace Hub_API.Controllers.SecurityModule.Master
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PrgPerController : ControllerBase
    {

        private readonly IPrgPer _GroupPermissionRepository;

        public PrgPerController(IPrgPer groupPermissionRepository)
        {
            _GroupPermissionRepository = groupPermissionRepository;
        }
        [HttpGet("showGroupPermission/{userid}")]
        public async Task<IActionResult> showGroupPermission([FromRoute] int userid)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.showGroupPermission(userid);
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
        public async Task<IActionResult> SaveGroupPermission([FromBody] List<UserPermissionDetailView> GroupPermission)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.SaveGroupPermission(GroupPermission);
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
        [HttpGet("showGroupPermissionwithparentid/{userID}/{Progid}")]
        public async Task<IActionResult> showGroupPermissionwithparentid([FromRoute] int userID, int Progid)
        {
            var apiResponse = new ApiResponse<List<UserPermissionDetailView>>();
            try
            {
                var data = await _GroupPermissionRepository.showGroupPermissionwithparentid(userID, Progid);
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
