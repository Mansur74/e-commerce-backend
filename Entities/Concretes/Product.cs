using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Color { get; set; }
        public int Stock { get; set; }
        public Shop Shop { get; set; }
        public ICollection<Cart> Carts {  get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<ProductCategory> Categories { get; set; }

    }
}
