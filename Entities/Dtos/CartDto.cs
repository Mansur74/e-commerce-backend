using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public UserDto? User { get; set; }
        public ProductDto? Product { get; set; }
    }
}
