using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    [Route("api")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopService _shopService;
        public ShopController(IShopService shopService) 
        {
            _shopService = shopService;
        }

        [HttpGet("/shop")]
        public IActionResult GetAllShops()
        {
            DataResult<ICollection<ShopDto>> shops = _shopService.GelAll();
            return Ok(shops);
        }

        [HttpPost("/user/{id}/shop")]
        public IActionResult CreateShop([FromBody] ShopDto shopDto, int id)
        {
            if(ModelState.IsValid)
            {
                Result result = _shopService.Create(shopDto, id);
                return Ok(result);
            }

            List<string> errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

            return StatusCode(400, new ErrorDataResult<List<string>>(errors));

        }


    }
}
