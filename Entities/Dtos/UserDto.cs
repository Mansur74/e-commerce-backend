using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname can not be empty.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName can not be empty.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age can not be empty.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "UserName can not be empty.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email can not be empty.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email can not be empty.")]
        [MinLength(6, ErrorMessage = "Passport size should be greater than 6")]
        [MaxLength(10, ErrorMessage = "Passport size should be less than 10")]
        public string Password { get; set; }

        public ICollection<Role>? Roles { get; set; }
        public ICollection<ShopDto>? Shops { get; set; }
        public ICollection<CartDto>? Carts { get; set; }
        public ICollection<OrderDto>? Orders { get; set; }
        public ICollection<Shipment>? Shipments { get; set; }
        public ICollection<ProductReviewDto>? ProductReviews { get; set; }
        public ICollection<ProductRateDto>? ProductRates { get; set; }
    }
}
