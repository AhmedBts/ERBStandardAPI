using Application;
using Domain.Entities.MainModule.Master;
using Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.MainModule.Master
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public CompanyController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<Company>>();
            try
            {
                var data = await unitOfWork.Company.GetAll();
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
        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                var data = await unitOfWork.Company.Delete(id);
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
        public async Task<IActionResult> Save([FromBody] Company obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<Company>();
            try
            {
                var data = await unitOfWork.Company.Save(obj);
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
        [HttpGet("Find/{Code}")]
        public async Task<IActionResult> Find([FromRoute] int CompanyCode)
        {
            var apiResponse = new ApiResponse<Company>();
            try
            {
                var data = await unitOfWork.Company.Find(c => c.CompanyCode == CompanyCode);
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
        public async Task<IActionResult> Update([FromBody] Company obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            var apiResponse = new ApiResponse<Company>();
            try
            {
                var data = await unitOfWork.Company.Update(obj);
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
