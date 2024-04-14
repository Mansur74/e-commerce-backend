using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ShopRateDto
    {
        public int ShopId { get; set; }
        public ShopDto? Shop { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int Rate { get; set; }
    }
}
