using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public UserDto? User { get; set; }
        public ShipmentDto? Shipment { get; set; }
        public PaymentDto? Payment { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
