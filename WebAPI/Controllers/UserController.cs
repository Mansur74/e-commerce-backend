using Business.Abstracts;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            DataResult<ICollection<UserDto>> users = _userService.GetAllUsers();
            return StatusCode(200, users);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            DataResult<UserDto> createdUser = _userService.CreateUser(user);
            return StatusCode(201, createdUser);
        }

        [HttpPost("zort")]
        public IActionResult CreateUdser([FromBody] UserDto user)
        {
  
            return StatusCode(201, user);
        }

    }
}
