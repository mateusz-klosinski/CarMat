using System.Threading.Tasks;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CarMat.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUserAsync(RegisterViewModel model);
        Task<bool> SignInUserAsync(string username, string password);
        Task SignOutUserAsync();
    }
}