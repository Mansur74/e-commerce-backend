using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<CartDto>? Carts { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<Wishlist>? Wishlists { get; set; }
        public ICollection<ProductCategory>? Categories { get; set; }
    }
}
