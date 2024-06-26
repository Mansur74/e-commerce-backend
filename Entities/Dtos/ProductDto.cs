﻿using Entities.Concretes;
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
        public string Name { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string ImgURL { get; set; }
        [Required]
        public int Stock { get; set; }
        public ShopDto? Shop { get; set; }
        public ICollection<ProductReviewDto>? Reviews { get; set; }
        public ICollection<ProductRateDto>? Rates { get; set; }
    }
}
