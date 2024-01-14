using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ITokenService
    {
        public string GenerateAccessToken(User user, List<Claim> claims);
        public string GenerateRefreshToken(User user, List<Claim> claims);
        public string ValidateRefreshToken(string refreshToken);
    }
}
