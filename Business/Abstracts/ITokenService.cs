using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ITokenService
    {
        public string GenerateAccessToken(string email);
        public string GenerateRefreshToken(string email);
        public string ValidateRefreshToken(string refreshToken);
    }
}
