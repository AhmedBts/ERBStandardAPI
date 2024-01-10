using Domain.Entities.MainModule.Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.MainModule.Master
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public BranchController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<Branch>>();
            try
            {
                var data = await unitOfWork.Branch.GetAll("Company");
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
                var data = await unitOfWork.Branch.Delete(id);
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
        public async Task<IActionResult> Save([FromBody] Branch obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiResponse = new ApiResponse<Branch>();
            try
            {
                var data = await unitOfWork.Branch.Save(obj);
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
        public async Task<IActionResult> Find([FromRoute] int BranchCode)
        {
            var apiResponse = new ApiResponse<Branch>();
            try
            {
                var data = await unitOfWork.Branch.Find(c => c.BranchCode == BranchCode);
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
        public async Task<IActionResult> Update([FromBody] Branch obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var apiResponse = new ApiResponse<Branch>();
            try
            {
                var data = await unitOfWork.Branch.Update(obj);
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
