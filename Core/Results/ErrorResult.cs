using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(true) { }
        public ErrorResult(String message) : base(true, message) { }
    }
}
