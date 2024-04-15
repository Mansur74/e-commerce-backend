using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ProductRateController : ControllerBase
    {
        IProductRateService _productRateService;
        public ProductRateController(IProductRateService productRateService)
        {
            _productRateService = productRateService;
        }

        [HttpPost("productRate")]
        public IActionResult Create([FromBody] ProductRateDto productRateDto, [FromQuery] int userId, [FromQuery] int productId)
        {
            Result result = _productRateService.Create(productRateDto, userId, productId);
            return StatusCode(201, result);
        }

        [HttpPut("productRate")]
        public IActionResult Update([FromBody] ProductRateDto productRateDto, [FromQuery] int userId, [FromQuery] int productId)
        {
            Result result = _productRateService.Update(productRateDto, userId, productId);
            return StatusCode(200, result);
        }

        [HttpGet("productRate")]
        public IActionResult GetById([FromQuery] int userId, [FromQuery] int productId)
        {
            Result result = _productRateService.GetById(userId, productId);
            return StatusCode(200, result);
        }

        [HttpGet("productRates")]
        public IActionResult GetAll()
        {
            DataResult<ICollection<ProductRateDto>> result = _productRateService.GetAll();
            return StatusCode(200, result);
        }
    }
}
