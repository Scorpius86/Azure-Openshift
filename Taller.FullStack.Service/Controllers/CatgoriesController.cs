using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taller.FullStack.Service.Infrastructure.Repositories;

namespace Taller.FullStack.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoriesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _unitOfWork.Categories.Get();
            return Ok(categories);
        }
    }
}
