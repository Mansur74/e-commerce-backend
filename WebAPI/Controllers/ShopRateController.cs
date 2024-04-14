using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ShopRateController : ControllerBase
    {
        IShopRateService _shopRateService;
        public ShopRateController(IShopRateService shopRateService)
        {
            _shopRateService = shopRateService;
        }

        [HttpPost("shopRate")]
        public IActionResult Create([FromBody] ShopRateDto shopRateDto, [FromQuery] int userId, [FromQuery] int shopId)
        {
            Result result = _shopRateService.Create(shopRateDto, userId, shopId);
            return StatusCode(201, result);
        }

        [HttpPut("shopRate")]
        public IActionResult Update([FromBody] ShopRateDto shopRateDto, [FromQuery] int userId, [FromQuery] int shopId)
        {
            Result result = _shopRateService.Update(shopRateDto, userId, shopId);
            return StatusCode(200, result);
        }

        [HttpGet("shopRate")]
        public IActionResult GetById([FromQuery] int userId, [FromQuery] int shopId)
        {
            Result result = _shopRateService.GetById(userId, shopId);
            return StatusCode(200, result);
        }

        [HttpGet("shopRates")]
        public IActionResult GetAll()
        {
            DataResult<ICollection<ShopRateDto>> result = _shopRateService.GetAll();
            return StatusCode(200, result);
        }
    }
}
