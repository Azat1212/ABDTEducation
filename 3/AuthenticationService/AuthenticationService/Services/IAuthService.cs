using System.Threading.Tasks;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Services
{
    public interface IAuthService
    {
        Task<ObjectResult> SignUp(SignUpModel signUpModel);
        Task<ObjectResult> Login(LoginModel loginModel);
    }
}