using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ShopReviewDto
    {
        public int Id { get; set; }
        public UserDto? User { get; set; }
        public ShopRateDto? Rate { get; set; }
        public string Review { get; set; }
    }
}
