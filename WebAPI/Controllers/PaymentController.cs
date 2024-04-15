using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        [HttpPost("/payment")]
        public ActionResult CreatePayment(PaymentDto paymentDto, int userId)
        {
            Result result = _paymentService.Create(paymentDto, userId);
            return StatusCode(201, result);
        }

        [HttpGet("/payment")]
        public ActionResult GetAllPayment() 
        {
            DataResult<ICollection<PaymentDto>> result = _paymentService.GetAll();
            return StatusCode(200, result);
        }

        [HttpGet("/payment/{paymentId}")]
        public ActionResult GetPaymentById(int paymentId)
        {
            DataResult<PaymentDto> result = _paymentService.GetById(paymentId);
            return StatusCode(200, result);
        }

    }
}
