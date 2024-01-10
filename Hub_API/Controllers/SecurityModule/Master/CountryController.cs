using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.SecurityModule.Master
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CountryController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public CountryController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet("Getall")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<Country>>();
            try
            {
                var data = await unitOfWork.Country.GetAll();
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
        [HttpDelete("Delete/{Id}/{Id2}")]
        public async Task<IActionResult> DeleteOne([FromRoute] int Id,int Id2)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await unitOfWork.Country.Delete(Id, Id2);
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
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await unitOfWork.Country.Delete(c=>c.CountryCode== Id);
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
        [HttpGet("Find/{CountryId}")]
        public async Task<IActionResult> Find([FromRoute] int CountryId)
        {
            var apiResponse = new ApiResponse<Country>();
            try
            {
                var data = await unitOfWork.Country.Find(c => c.CountryCode == CountryId);
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
        public async Task<IActionResult> Save([FromBody] Country obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<Country>();
            try
            {
                var data = await unitOfWork.Country.Save(obj
                   
                    );
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
        public async Task<IActionResult> Update([FromBody] Country obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<Country>();
            try
            {
                var data = await unitOfWork.Country.Update(obj);
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