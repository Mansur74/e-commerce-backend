using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopService _shopService;
        public ShopController(IShopService shopService) 
        {
            _shopService = shopService;
        }

        [HttpGet("shop")]
        public IActionResult GetAllShops()
        {
            DataResult<ICollection<ShopDto>> shops = _shopService.GetAll();
            return Ok(shops);
        }

        [HttpGet("shops")]
        public IActionResult GetPage([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            DataResult<PageResult<ShopDto>> shops = _shopService.GetPage(pageNumber, pageSize);
            return Ok(shops);
        }

        [HttpGet("shop/{shopId}")]
        public IActionResult GetShopById(int shopId)
        {
            DataResult<ShopDto> result = _shopService.GetById(shopId);
            return Ok(result);
        }

        [ValidationFilter]
        [HttpPost("user/{userId}/shop")]
        public IActionResult CreateShop([FromBody] ShopDto shopDto, int userId)
        {
            Result result = _shopService.Create(shopDto, userId);
            return Ok(result);
        }

        [ValidationFilter]
        [HttpPut("shop/{shopId}")]
        public IActionResult UpdateShop([FromBody] ShopDto shopDto, int shopId)
        {
            Result result = _shopService.Update(shopDto, shopId);
            return Ok(result);
        }


    }
}
