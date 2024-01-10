
using Domain.Entities.ReservationModule;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.MasterModels
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesMasterController : ControllerBase
    {
       
        private IUnitOfWork unitOfWork;
        public SalesMasterController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }
        [HttpGet("GetAllBPType")]
        public async Task<IActionResult> Getall()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("GetAllProcessTypeForWeb()");
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
        [HttpGet("GetAllSubLedgerCode")]
        public async Task<IActionResult> GetAllSubLedgerCode()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("AllSubLedgerCodeForWeb()");
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
        [HttpGet("GetAllShipTo")]
        public async Task<IActionResult> GetAllShipTo()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("GetAllShipToForWeb()");
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
        [HttpGet("GetAllStore")]
        public async Task<IActionResult> GetAllStore()
        {
            var apiResponse = new ApiResponse<List<dynamic>>(); 
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("GetAllStoreForWeb()");
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

        [HttpGet("GetAllCurrency")]
        public async Task<IActionResult> GetAllCurrency()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("GetAllCurrencyForWeb()");
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
            //GetAllOrderStatusForWeb
        }

        [HttpGet("GetAllOrderStatus")]
        public async Task<IActionResult> GetAllOrderStatusForWeb()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("GetAllOrderStatusForWeb()");
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
            //GetAllOrderStatusForWeb
        }
    }
}
