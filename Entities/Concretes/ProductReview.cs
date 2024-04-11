using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public ProductRate Rate { get; set; }
        public string Review { get; set; }
        
    }
}
