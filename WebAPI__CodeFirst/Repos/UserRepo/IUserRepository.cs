using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI__CodeFirst.Classes;

namespace WebAPI__CodeFirst.Repos.UserRepo
{
    public interface IUserRepository
    {
        Task<String> LoginAsync([FromBody] UserCred user);

        Task<UserCred> RegisterAsync([FromBody] UserCred user);
    }
}

