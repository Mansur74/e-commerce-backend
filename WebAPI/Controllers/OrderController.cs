using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost("/order")]
        public IActionResult CreateOrder(OrderDto orderDto, [FromQuery] int userId, [FromQuery] int shipmentId, [FromQuery] int paymentId)
        {
            Result result = _orderService.Create(orderDto, userId, shipmentId, paymentId);
            return StatusCode(201, result);
        }

        [HttpGet("/order")]
        public IActionResult GelAllOrders()
        {
            DataResult<ICollection<OrderDto>> orders = _orderService.GetAll();
            return Ok(orders);  
        }

        [HttpGet("/order/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            DataResult<OrderDto> order = _orderService.GetById(orderId);
            return Ok(order);
        }


    }
}
