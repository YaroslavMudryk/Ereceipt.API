using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<User> RegisterUserAsync(RegisterUserModel model);
        Task<Token> LoginUserAsync(LoginUserModel model);
        string Token { get; }
    }
}