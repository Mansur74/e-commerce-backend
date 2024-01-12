using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenService _tokenService;

        public AuthService(IUserDal userDal, ITokenService tokenService)
        {
            this._userDal = userDal;
            this._tokenService = tokenService;
        }

        public AccessTokenDto GetAccessToken(RefreshTokenDto refreshToken)
        {
            string email = this._tokenService.ValidateRefreshToken(refreshToken.RefreshToken);
            string accessToken = _tokenService.GenerateAccessToken(email);
            return new AccessTokenDto { AccessToken = accessToken };

        }

        public JwtResponseDto Login(AuthRequestDto request)
        {
            User user = _userDal.GetUserByEmail(request.Email);
            if (user != null && request.Email.Equals(user.Email))
            {
                string accessToken = _tokenService.GenerateAccessToken(user.Email);
                string refreshToken = _tokenService.GenerateRefreshToken(user.Email);
                return new JwtResponseDto { AccessToken = accessToken, RefreshToken = refreshToken };
            }
            else
                throw new Exception("Username does't exists");
        }
    }
}
