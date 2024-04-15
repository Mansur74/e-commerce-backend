using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost("/orderitem")]
        public IActionResult Create([FromBody] OrderItemDto orderItemDto, [FromQuery] int productId, [FromQuery] int orderId)
        {
            Result result = _orderItemService.Create(orderItemDto, productId, orderId);
            return StatusCode(201, result);
        }
    }
}
