using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductRateDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User? User { get; set; }
        public int Rate { get; set; }
    }
}
