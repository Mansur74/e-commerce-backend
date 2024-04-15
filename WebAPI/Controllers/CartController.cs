using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("cart")]
        public IActionResult CreateCart([FromBody] CartDto cartDto, [FromQuery] int userId, [FromQuery] int productId)
        {
            Result result = _cartService.Create(cartDto, userId, productId);
            return StatusCode(201, result);

        }

        [HttpPut("cart/{cartId}")]
        public IActionResult UpdateCart([FromBody] CartDto cartDto, int cartId)
        {
            Result result = _cartService.Update(cartDto, cartId);
            return StatusCode(200, result);

        }

        [HttpGet("cart")]
        public IActionResult GetAllCarts()
        {
            DataResult<ICollection<CartDto>> result = _cartService.GetAllCarts();
            return StatusCode(200, result);

        }
        [HttpDelete("cart/{cartId}")]
        public IActionResult DeleteCart(int cartId)
        {
            Result result = _cartService.Delete(cartId);
            return StatusCode(200, result);

        }

    }
}
