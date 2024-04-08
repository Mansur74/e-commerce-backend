using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {

        IProductReviewService _productReviewService;
        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        [HttpPost("productReview")]
        public IActionResult Create([FromBody] ProductReviewDto productReviewDto, [FromQuery] int userId, [FromQuery] int productId)
        {
            Result result = _productReviewService.Create(productReviewDto, userId, productId);
            return StatusCode(201, result);
        }

        [HttpDelete("productReview/{reviewId}")]
        public IActionResult Delete(int reviewId)
        {
            Result result = _productReviewService.Delete(reviewId);
            return StatusCode(200, result);
        }

        [HttpGet("productReview")]
        public IActionResult GetAll()
        {
            DataResult<ICollection<ProductReviewDto>> result = _productReviewService.GetAll();
            return StatusCode(200, result);
        }

    }
}
