namespace Hub_API.Controllers.SecurityModule.Master
{
  /// <summary>
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class GroupController : Controller
    {
        private IUnitOfWork unitOfWork;
        public GroupController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet("Getall")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<Group>>();
            try
            {
                var data =  await unitOfWork.Groups.GetAll();
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
        [HttpDelete("Delete/{GroupId}")]
        public async Task<IActionResult> Delete([FromRoute] int GroupId)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await unitOfWork.Groups.Delete(GroupId);
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
        [HttpGet("Find/{GroupId}")]
        public async Task<IActionResult> Find([FromRoute] int GroupId)
        {
            var apiResponse = new ApiResponse<Group>();
            try
            {
                var data = await unitOfWork.Groups.GetByIdAsync(GroupId);
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
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] Group obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<Group>();
            try
            {
                var data = await unitOfWork.Groups.Save(obj);
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
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Group obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<Group>();
            try
            {
                var data = await unitOfWork.Groups.Update(obj);
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