using WebAPI__CodeFirst.Model;

namespace WebAPI__CodeFirst.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string passwrod);
    }
}
