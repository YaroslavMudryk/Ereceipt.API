using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class IdentityService : IIdentityService
    {
        private WebRequest webRequest;
        private string token;
        private string basicRoute { get; }
        public IdentityService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Identity.Basic;
        }

        public string Token => token;

        public async Task<Token> LoginUserAsync(LoginUserModel model)
        {
            var response = await webRequest.PostAsync<Token>($"{basicRoute}/login", model);
            if (response.OK)
            {
                token = response.Data.AccessToken;
                return response.Data;
            }
            return null;
        }

        public async Task<User> RegisterUserAsync(RegisterUserModel model)
        {
            var response = await webRequest.PostAsync<User>($"{basicRoute}/register", model);
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}