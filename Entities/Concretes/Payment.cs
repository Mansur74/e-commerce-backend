using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();


    }
}
