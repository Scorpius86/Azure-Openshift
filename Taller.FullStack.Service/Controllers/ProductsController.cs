using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taller.FullStack.Service.Infrastructure.Repositories;

namespace Taller.FullStack.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _unitOfWork.Products.Get(includeProperties: "Category,Brand");
            return Ok(products);
        }
    }
}
