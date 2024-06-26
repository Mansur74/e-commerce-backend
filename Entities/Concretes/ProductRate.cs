﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ProductRate
    {
        public int UserId { get; set; }    
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Rate { get; set; }
        public ICollection<ProductReview> Reviews { get; set;}
        
    }
}
