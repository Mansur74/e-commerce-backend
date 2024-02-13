using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRateController : ControllerBase
    {
        IProductRateService _productRateService;
        public ProductRateController(IProductRateService productRateService)
        {
            _productRateService = productRateService;
        }

        [HttpPost("/productRate")]
        public IActionResult Create([FromBody] ProductRateDto productRateDto, [FromQuery] int userId, [FromQuery] int productId)
        {
            Result result = _productRateService.Create(productRateDto, userId, productId);
            return StatusCode(201, result);
        }

        [HttpGet("/productRate")]
        public IActionResult GetAll()
        {
            DataResult<ICollection<ProductRateDto>> result = _productRateService.GetAll();
            return StatusCode(200, result);
        }
    }
}
