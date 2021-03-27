using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class IdentityService : IIdentityService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        private string token;
        public IdentityService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
        }

        public string Token => token;

        public async Task<Token> LoginUserAsync(LoginUserModel model)
        {
            var response = await webRequest.PostAsync<Token>("login", model);
            if (response.OK)
            {
                token = response.Data.AccessToken;
                return response.Data;
            }
            return null;
        }

        public async Task<User> RegisterUserAsync(RegisterUserModel model)
        {
            var response = await webRequest.PostAsync<User>("register", model);
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}