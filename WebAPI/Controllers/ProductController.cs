using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet("product")]
        public IActionResult GetProducts() 
        {
            DataResult<ICollection<ProductDto>> result = _productService.GetAll();
            return StatusCode(200, result);
        }

        [HttpGet("product/{productId}")]
        public IActionResult GetProductById(int productId)
        {
            DataResult<ProductDto> result = _productService.GetById(productId);
            return StatusCode(200, result);
 
        }

        [ValidationFilter]
        [HttpPost("shop/{shopId}/product")]
        public IActionResult CreateProduct([FromBody] ProductDto productDto, int shopId, [FromQuery] int categoryId)
        {
            Result result = _productService.Create(productDto, shopId, categoryId);
            return StatusCode(201, result);
        }

        [ValidationFilter]
        [HttpPut("product/{productId}")]
        public IActionResult UpdateProduct([FromBody] ProductDto productDto, int productId)
        {
            Result result = _productService.Update(productDto, productId);
            return StatusCode(200, result);
        }

        [HttpDelete("product/{productId}")]
        public IActionResult DeleteProduct( int productId)
        {
            Result result = _productService.Delete(productId);
            return StatusCode(200, result);
        }

    }
}
