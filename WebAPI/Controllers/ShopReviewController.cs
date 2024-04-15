using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ShopReviewController : ControllerBase
    {
        IShopReviewService _shopReviewService;
        public ShopReviewController(IShopReviewService shopReviewService)
        {
            _shopReviewService = shopReviewService;
        }

        [HttpPost("shopReview")]
        public IActionResult Create([FromBody] ShopReviewDto shopReviewDto, [FromQuery] int userId, [FromQuery] int shopId)
        {
            Result result = _shopReviewService.Create(shopReviewDto, userId, shopId);
            return StatusCode(201, result);
        }

        [HttpDelete("shopReview/{reviewId}")]
        public IActionResult Delete(int reviewId)
        {
            Result result = _shopReviewService.Delete(reviewId);
            return StatusCode(200, result);
        }

        [HttpGet("shopReview")]
        public IActionResult GetAll()
        {
            DataResult<ICollection<ShopReviewDto>> result = _shopReviewService.GetAll();
            return StatusCode(200, result);
        }
    }
}
