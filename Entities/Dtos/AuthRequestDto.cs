using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AuthRequestDto
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Passport size should be greater than 6")]
        [MaxLength(10, ErrorMessage = "Passport size should be less than 10")]
        public string Password { get; set; }
    }
}
