using Domain.Entities.MainModule.Master;
using Domain.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.MainModule.Master
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
      
        public CustomerController(IUnitOfWork _unitOfWork)
            {
                unitOfWork = _unitOfWork;

            }

            [HttpGet("Find/{Code}")]
            public async Task<IActionResult> Find([FromRoute] int CustomerCode)
            {
                var apiResponse = new ApiResponse<Customer>();
                try
                {
                    var data = await unitOfWork.Customer.Find(c => c.CustCode == CustomerCode);
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

            [HttpGet("Getall")]
            public async Task<IActionResult> Getall()
            {
                var apiResponse = new ApiResponse<List<Customer>>();
                try
                {
                    var data = await unitOfWork.Customer.GetAll();
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
                    var data = await unitOfWork.Customer.Delete(id);
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
            public async Task<IActionResult> Save([FromBody] CustomerLogo obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var apiResponse = new ApiResponse<Customer>();
                try
                {
                    var data = await unitOfWork.Customer.Save(obj.Customer,obj.Logo);
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
            public async Task<IActionResult> Update([FromBody] CustomerLogo obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
             
                var apiResponse = new ApiResponse<Customer>();
                try
                {
                    var data = await unitOfWork.Customer.Update(obj.Customer,obj.Logo);
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


