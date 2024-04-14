using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FoundedAt { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ShopReview> Reviews { get; set; }
        public ICollection<ShopRate> Rates { get; set; }
    }
}
