using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System.Security.Claims;

namespace DataAccess.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenService _tokenService;

        public AuthManager(IUserDal userDal, ITokenService tokenService)
        {
            _userDal = userDal;
            _tokenService = tokenService;
        }

        public DataResult<AccessTokenDto> GetAccessToken(RefreshTokenDto refreshToken)
        {
            string email = this._tokenService.ValidateRefreshToken(refreshToken.RefreshToken);
            User user = _userDal.GetUserByEmail(email);
            List<Claim> claims = new List<Claim> {
                        new Claim("email", user.Email),
                    };

            foreach (var userRole in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }
            string accessToken = _tokenService.GenerateAccessToken(user, claims);
            return new SuccessDataResult<AccessTokenDto>(new AccessTokenDto { AccessToken = accessToken });

        }

        public DataResult<JwtResponseDto> Login(AuthRequestDto request)
        {
            User user = _userDal.GetUserByEmail(request.Email);
            if (user != null && request.Email.Equals(user.Email))
            {
                List<Claim> claims = new List<Claim> {
                        new Claim("email", user.Email),
                    };

                foreach (var userRole in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                }
                string accessToken = _tokenService.GenerateAccessToken(user, claims);
                string refreshToken = _tokenService.GenerateRefreshToken(user, claims);
                return new SuccessDataResult<JwtResponseDto>(new JwtResponseDto {AccessToken = accessToken, RefreshToken = refreshToken });
            }
            else
                throw new Exception("Username does't exists");
        }
    }
}
