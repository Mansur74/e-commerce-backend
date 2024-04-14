using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ShopRate
    {
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int UserId { get; set; }
        public User User {  get; set; }
        public int Rate { get; set; }
        public ICollection<ShopReview> Reviews { get; set; } 
    }
}
