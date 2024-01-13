using Core.Utilities.Results;
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
        public DataResult<JwtResponseDto> Login(AuthRequestDto request);
        public DataResult<AccessTokenDto> GetAccessToken(RefreshTokenDto refreshToken);
    }
}
