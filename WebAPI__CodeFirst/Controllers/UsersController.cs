using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI__CodeFirst.Authentication;
using WebAPI__CodeFirst.Classes;
using WebAPI__CodeFirst.Repos.UserRepo;

namespace WebAPI__CodeFirst.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserCred user)
        {
            var token = await _userRepository.LoginAsync(user);
            return token == null ? Unauthorized() : Ok(token);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<UserCred> Register([FromBody] UserCred user)
        {
            return await _userRepository.RegisterAsync(user);
        }
    }
}
