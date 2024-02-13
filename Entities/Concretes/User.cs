using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole>? Roles { get; set; }
        public ICollection<Shop>? Shops { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Wishlist>? Wishlists { get; set; }
        public ICollection<Shipment>? Shipments { get; set; }
        public ICollection<ProductReview>? ProductReviews { get; set; }
        public ICollection<ProductRate>? ProductRates { get; set; }
    }
}
