using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI__CodeFirst.Authentication;
using WebAPI__CodeFirst.Classes;

namespace WebAPI__CodeFirst.Repos.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager,
             IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }


        public async Task<String> LoginAsync([FromBody] UserCred user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.username, user.password, user.rememberMe, false);

            if (result.Succeeded)
            {
                var token = _jwtAuthenticationManager.Authenticate(user.username, user.password);
                if (token == null) return null;
                return token;
            }
            return null;
        }


        public async Task<UserCred> RegisterAsync([FromBody] UserCred user)
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
    }
}

