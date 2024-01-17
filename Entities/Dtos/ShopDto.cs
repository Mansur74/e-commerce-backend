using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ShopDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description can not be empty.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Founded date and time can not be empty.")]
        public DateTime FoundedAt { get; set; }
    }
}
