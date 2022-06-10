using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTest.Interfaces.Base.UnitsOfWork;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesUnitOfWork _unitOfWork;

        public SalesController(ISalesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllInfo()
        {
            return Ok(_unitOfWork.GetAll());
        }

        [HttpPost]
        public IActionResult Sale()
        {
            return default;
        }
    }
}
