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
        public string BasicRoute { get; }

        public UserService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
            BasicRoute = ApiRoutes.V1.Users.Basic;
        }


        public async Task<User> EditUserAsync(UserEditModel model)
        {
            var response = await webRequest.PutAsync<User>($"{BasicRoute}/{model.Id}", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<User>> GetAllUsers(int afterId = 0)
        {
            var response = await webRequest.GetAsync<List<User>>($"{BasicRoute}?afterId={afterId}");
            if(response.OK)
            {
                return response.Data;
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await webRequest.GetAsync<User>($"{BasicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<User>> SearchUsersAsync(string name, int afterId = 0)
        {
            var response = await webRequest.GetAsync<List<User>>($"{BasicRoute}/search?name={name}&aftedId={afterId}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}