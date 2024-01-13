using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;

namespace DataAccess.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenService _tokenService;

        public AuthManager(IUserDal userDal, ITokenService tokenService)
        {
            this._userDal = userDal;
            this._tokenService = tokenService;
        }

        public DataResult<AccessTokenDto> GetAccessToken(RefreshTokenDto refreshToken)
        {
            string email = this._tokenService.ValidateRefreshToken(refreshToken.RefreshToken);
            string accessToken = _tokenService.GenerateAccessToken(email);
            return new SuccessDataResult<AccessTokenDto>(new AccessTokenDto { AccessToken = accessToken });

        }

        public DataResult<JwtResponseDto> Login(AuthRequestDto request)
        {
            User user = _userDal.GetUserByEmail(request.Email);
            if (user != null && request.Email.Equals(user.Email))
            {
                string accessToken = _tokenService.GenerateAccessToken(user.Email);
                string refreshToken = _tokenService.GenerateRefreshToken(user.Email);
                return new SuccessDataResult<JwtResponseDto>(new JwtResponseDto {AccessToken = accessToken, RefreshToken = refreshToken });
            }
            else
                throw new Exception("Username does't exists");
        }
    }
}
