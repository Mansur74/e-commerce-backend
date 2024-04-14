using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ShopReview
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public User User { get; set; }
        public ShopRate Rate { get; set; }
        public string Review { get; set; }
    }
}
