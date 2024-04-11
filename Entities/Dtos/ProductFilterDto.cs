using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductFilterDto
    {
        public ICollection<string>? categories {  get; set; }
        public ICollection<string>? colors { get; set; }
        public ICollection<int>? rates { get; set; }
    }
}
