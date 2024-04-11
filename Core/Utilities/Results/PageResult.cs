using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class PageResult <T>
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public ICollection<T>? rows { get; set; }
    }
}
