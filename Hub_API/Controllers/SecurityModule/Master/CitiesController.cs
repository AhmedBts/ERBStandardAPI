using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.SecurityModule.Master
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        BaseRepository<City> _baseRepository;
        IUserService _userService;
        public CitiesController(BaseRepository<City> baseRepository,IUserService userService)
        {
            this._baseRepository = baseRepository;
            _userService = userService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Find()
        {
            var apiResponse = new ApiResponse<List<City>>();
            try
            {
                var data = await _baseRepository.FindAll(c=>c.CountryCode == _userService.GetUserCountry());
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
