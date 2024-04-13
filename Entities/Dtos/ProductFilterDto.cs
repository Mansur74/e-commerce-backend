using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductFilterDto
    {
        public ICollection<string>? Categories {  get; set; }
        public ICollection<string>? Colors { get; set; }
        public ICollection<int>? Rates { get; set; }
        public string? Search {  get; set; }
    }
}
