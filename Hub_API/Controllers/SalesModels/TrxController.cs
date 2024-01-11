using Application.Interface.Sales;
using Domain.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.SalesModels
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TrxController : ControllerBase
    {
        private ITrx unitOfWork;
        public TrxController(ITrx _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }


        [HttpGet("GetAllOrder/{BranchCode}/{Type}/{Year}")]
        public async Task<IActionResult> Getall(int BranchCode, int Type, int Year)
        {
            var apiResponse = new ApiResponse<List<TrxH>>();
            try
            {
                var data = await unitOfWork.GetAllH(BranchCode,  Type, Year);
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

        [HttpGet("GetTrxDs/{BranchCode}/{Type}/{Year}/{serial}")]
        public async Task<IActionResult> GetOrderDs(int BranchCode, int Type, int Year, int serial)
        {
            var apiResponse = new ApiResponse<List<TrxD>>();
            try
            {
                var data = await unitOfWork.GetOrderDs(BranchCode,  Type, Year, serial);
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
        [HttpDelete("Delete/{BranchCode}/{Type}/{Year}/{serial}")]
        public async Task<IActionResult> Delete(int BranchCode,  int Type, int Year, int serial)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = await unitOfWork.Delete(BranchCode,  Type, Year, serial);
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
        public async Task<IActionResult> Save(TrxH obj)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = await unitOfWork.Save(obj);
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
        [HttpPost("Update")]
        public async Task<IActionResult> Update(TrxH obj)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = await unitOfWork.Update(obj);
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
