using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userManager;
        public UserController(IUserService userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            ICollection<User> users = _userManager.GetAllUsers();
            return StatusCode(200, users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            User createdUser = _userManager.CreateUser(user);
            return StatusCode(201, createdUser);
        }

    }
}
