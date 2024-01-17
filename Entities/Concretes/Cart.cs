using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        User User { get; set; }
        Product Product { get; set; }
       

    }
}
