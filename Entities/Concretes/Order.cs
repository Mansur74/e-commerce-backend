using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public Shipment Shipment { get; set; }
        public Payment Payment { get; set; }
        public ICollection<OrderItem> OrderItems {  get; set; }
    }
}
