using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI__CodeFirst.Authentication;
using WebAPI__CodeFirst.Model;

namespace WebAPI__CodeFirst.Controllers

{
    [Route("users")]

    public class UsersController : Controller
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
       

        public UsersController(UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager,
             IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<UserCred> Register([FromBody]UserCred user)
        {
            var newUser = new IdentityUser
            {
                UserName = user.username,
                PasswordHash = user.password,
            };

            var result = await _userManager.CreateAsync(newUser, user.password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: false);
            }
            return user;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserCred user)
        {          
            var result = await _signInManager.PasswordSignInAsync(user.username, user.password, user.rememberMe, false);

            if (result.Succeeded)
            {
                var token = _jwtAuthenticationManager.Authenticate(user.username, user.password);
                if (token == null) return Unauthorized();
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
