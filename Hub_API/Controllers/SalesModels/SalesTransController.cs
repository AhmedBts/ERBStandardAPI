using Application.Interface.Sales;
using Domain.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.SalesModels
{  //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesTransController : ControllerBase
    {
        private IOrder unitOfWork;
        public SalesTransController(IOrder _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }


        [HttpGet("GetAllOrder/{BranchCode}/{ProcessType}/{Type}/{Year}")]
        public async Task<IActionResult> Getall( int BranchCode, string ProcessType, int Type, int Year)
        {
            var apiResponse = new ApiResponse<List<OrderH>>();
            try
            {
                var data = await unitOfWork.GetAllH( BranchCode,  ProcessType,  Type,  Year);
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

        [HttpGet("GetOrderDs/{BranchCode}/{ProcessType}/{Type}/{Year}/{serial}")]
        public async Task<IActionResult> GetOrderDs(int BranchCode, string ProcessType, int Type, int Year, int serial)
        {
            var apiResponse = new ApiResponse<List<OrderD>>();
            try
            {
                var data = await unitOfWork.GetOrderDs(BranchCode, ProcessType, Type, Year, serial);
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
        [HttpDelete("Delete/{BranchCode}/{ProcessType}/{Type}/{Year}/{serial}")]
        public async Task<IActionResult> Delete(int BranchCode, string ProcessType, int Type, int Year, int serial)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = await unitOfWork.Delete(BranchCode, ProcessType, Type, Year, serial);
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
        public async Task<IActionResult> Save(OrderH obj)
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
        public async Task<IActionResult> Update(OrderH obj)
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
