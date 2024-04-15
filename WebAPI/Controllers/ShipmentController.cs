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
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpPost("/user/{userId}/shipment")]
        public IActionResult CreateShipment(ShipmentDto shipmentDto, int userId)
        {
            Result result = _shipmentService.Create(shipmentDto, userId);
            return StatusCode(201, result);
        }

        [HttpPut("/shipment/{shipmentId}")]
        public IActionResult UpdateShipment(ShipmentDto shipmentDto, int shipmentId)
        {
            Result result = _shipmentService.Update(shipmentDto, shipmentId);
            return StatusCode(200, result);
        }

        [HttpGet("/shipment")]
        public IActionResult GetShipments()
        {
            DataResult<ICollection<ShipmentDto>> result = _shipmentService.GetAll();
            return StatusCode(200, result);
        }

        [HttpGet("/shipment/{shipmentId}")]
        public IActionResult GetShipmentById(int shipmentId)
        {
            DataResult<ShipmentDto> result = _shipmentService.GetById(shipmentId);
            return StatusCode(200, result);
        }

        [HttpDelete("/shipment/{shipmentId}")]
        public IActionResult DeleteShipment(int shipmentId)
        {
            Result result = _shipmentService.Delete(shipmentId);
            return StatusCode(200, result);
        }


    }
}
