using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class Result
    {
        public string? Message { get; set; }
        public bool Success { get; set; }

        public Result(bool success)
        {
            this.Success = success;
            this.Message = null;
        }
        public Result(bool success, String message) 
        {
            this.Success = success;
            this.Message = message;
        }

    }

}
