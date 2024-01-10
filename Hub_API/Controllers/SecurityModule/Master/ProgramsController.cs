

namespace AlMithaliApi.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class ProgramsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProgramsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetDataByParentProgID/{ProgID},{Lang}")]

        public async Task<IActionResult> GetDataByParentProgID([FromRoute] decimal ProgID, int Lang)
        {
            var apiResponse = new ApiResponse<List<MenuItemView>>();
            try
            {
                bool SysLang = true;
                if (Lang == 0)
                    SysLang = false;
                var result = await _unitOfWork.Programs.GetDataByParentProgID(ProgID, SysLang);

                apiResponse.Success = true;
                apiResponse.Result = result.ToList();
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
        [HttpGet("GetPageByUserID/{UserId},{Lang},{ProgID}")]

        public async Task<IActionResult> GetPageByUserID([FromRoute] int UserId, int Lang, decimal ProgID)
        {

            var apiResponse = new ApiResponse<List<MenuItemView>>();
            try
            {
                bool SysLang = true;
                if (Lang == 0)
                    SysLang = false;
                var result = await _unitOfWork.Programs.GetPageByUserID(UserId, SysLang, ProgID);

                apiResponse.Success = true;
                apiResponse.Result = result.ToList();
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
        [HttpGet("GetProgramsByUserID/{UserId},{Lang},{ProgID}")]

        public async Task<IActionResult> GetProgramsByUserID([FromRoute] int UserId, int Lang, decimal ProgID)
        {
            var apiResponse = new ApiResponse<List<MenuItemView>>();
            try
            {
                bool SysLang = true;
                if (Lang == 0)
                    SysLang = false;
                var result = await _unitOfWork.Programs.GetProgramsByUserID(UserId, SysLang, ProgID);

                apiResponse.Success = true;
                apiResponse.Result = result.ToList();
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
        [HttpGet("GetProgramsDetailByGroupId/{GroupId}")]

        public async Task<IActionResult> GetProgramsDetailByGroupId([FromRoute] int GroupId)
        {
            var apiResponse = new ApiResponse<List<Domain.Entities.SecurityModule.Master.Program>>();
            try
            {
                var result = await _unitOfWork.Programs.GetProgramsDetailByGroupId(GroupId);

                apiResponse.Success = true;
                apiResponse.Result = result.ToList();
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


        [HttpGet("GetProgpermissionperuser/{ProgID}/{id}")]

        public async Task<IActionResult> GetProgpermissionperuser(decimal ProgID, int id)
        {
            var apiResponse = new ApiResponse<PrgPer>();
            try
            {
                var result = await _unitOfWork.Programs.GetProgpermissionperuser(ProgID, id);

                apiResponse.Success = true;
                apiResponse.Result = result;
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
        [HttpGet("GetProg/{ProgID}")]

        public async Task<IActionResult> GetProg(decimal ProgID)
        {


            var apiResponse = new ApiResponse<Domain.Entities.SecurityModule.Master.Program>();
            try
            {
                var result = await _unitOfWork.Programs.GetProg(ProgID);

                apiResponse.Success = true;
                apiResponse.Result = result;
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
