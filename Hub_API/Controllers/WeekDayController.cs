

using Domain.Entities.ReservationModule;

namespace Hub_API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class WeekDayController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public WeekDayController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet("Getall")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<WeekDay>>();
            try
            {
                var data = await unitOfWork.WeekDay.GetAll();
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
