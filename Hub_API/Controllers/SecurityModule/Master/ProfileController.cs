using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hub_API.Controllers.SecurityModule.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

    }
}
