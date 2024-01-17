using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public Result(bool success)
        {
            Success = success;
     
        }
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

    }

}
