using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taller.FullStack.Service.Infrastructure.Repositories;

namespace Taller.FullStack.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public BrandsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var brands = _unitOfWork.Brands.Get();
            return Ok(brands);
        }
    }
}
