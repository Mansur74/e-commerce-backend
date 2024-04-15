using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class SecurityUtil
    {
        public static string getUserEmail()
        {
            HttpContext _httpContext = new HttpContextAccessor().HttpContext;
            return _httpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value!;
        }
    }
}
