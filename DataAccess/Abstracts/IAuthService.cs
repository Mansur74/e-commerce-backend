using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IAuthService
    {
        public JwtResponseDto Login(AuthRequestDto request);
        public AccessTokenDto GetAccessToken(RefreshTokenDto refreshToken);
    }
}
