using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.SalesMasterModels
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesMasterDetailController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public SalesMasterDetailController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }
        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("GetAllItemsForWeb()");
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

        [HttpGet("GetAllUnitCode")]
        public async Task<IActionResult> GetAllUnitCode()
        {
            var apiResponse = new ApiResponse<List<dynamic>>();
            try
            {
                var data = await unitOfWork.SalesMaster.GetAllSalesMaster("UnitCode");
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

        [HttpPost("GetAllItemData")]
        public async Task<IActionResult> GetAllItemData([FromBody] ItemViewData itemViewData)
        {
            var apiResponse = new ApiResponse<ItemViewDataResult>();
            //

            ///
            try
            {
                var data = await unitOfWork.SalesMaster.GetItemData( itemViewData);
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
