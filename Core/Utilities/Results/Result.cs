using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result
    {
        public string? Message { get; set; }
        public bool Success { get; set; }

        public Result(bool success)
        {
            Success = success;
            Message = null;
        }
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

    }

}
