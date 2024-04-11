using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public ProductRate? Rate { get; set; }
        public string Review { get; set; }

    }
}
