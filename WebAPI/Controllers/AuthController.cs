using DataAccess.Abstracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] AuthRequestDto body)
        {
            JwtResponseDto result = _authService.Login(body);
            return Ok(result);
        }

        [HttpPost("/accessToken")]
        public IActionResult GetAccessToken([FromBody] RefreshTokenDto body)
        {
            AccessTokenDto result = _authService.GetAccessToken(body);
            return Ok(result);
        }
    }
}
