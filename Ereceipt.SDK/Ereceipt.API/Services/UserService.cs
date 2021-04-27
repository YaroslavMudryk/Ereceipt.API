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
    public class UserService : IUserService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        private int lastUserId;
        public UserService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
        }

        public int LastUserId => lastUserId;

        public async Task<User> EditUserAsync(UserEditModel model)
        {
            var response = await webRequest.PutAsync<User>($"{urls.Users}/{model.Id}", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<User>> GetAllUsers(int afterId = 0)
        {
            var response = await webRequest.GetAsync<List<User>>($"{urls.Users}?afterId={afterId}");
            if(response.OK)
            {
                lastUserId = response.Data.LastOrDefault().Id;
                return response.Data;
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await webRequest.GetAsync<User>($"{urls.Users}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<User>> SearchUsersAsync(string name, int afterId = 0)
        {
            var response = await webRequest.GetAsync<List<User>>($"{urls.Users}/search?name={name}&aftedId={afterId}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}