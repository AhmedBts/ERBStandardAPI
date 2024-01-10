
namespace Hub_API.Controllers.SecurityModule.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateMasterFrontController : ControllerBase
    {
        private readonly ICreateMasterFront _CreateMasterFront;

        public CreateMasterFrontController(ICreateMasterFront createMasterFront)
        {
            _CreateMasterFront = createMasterFront;
        }
        [HttpGet("CreateFormMaster/{userid}")]
        public async Task<IActionResult> CreateFormMaster([FromRoute] string userid)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await _CreateMasterFront.CreateFormMaster(userid);
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
