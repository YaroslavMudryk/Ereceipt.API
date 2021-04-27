using Ereceipt.API.Models.Helpers;
using System.Threading.Tasks;

namespace Ereceipt.API
{
    public interface IReceiptClient
    {
        Task LoginAsync(LoginUserModel model);
        Task RegisterAsync(RegisterUserModel model);
        Task SaveTokenAsync();
        Task GetTokenAsync();
        public string Token { get; }
    }
}