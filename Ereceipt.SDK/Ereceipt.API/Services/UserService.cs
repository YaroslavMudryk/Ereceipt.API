using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class UserService : IUserService
    {
        private WebRequest webRequest;
        private string basicRoute { get; }

        public UserService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Users.Basic;
        }


        public async Task<User> EditUserAsync(UserEditModel model)
        {
            var response = await webRequest.PutAsync<User>($"{basicRoute}/{model.Id}", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<User>> GetAllUsers(int afterId = 0)
        {
            var response = await webRequest.GetAsync<List<User>>($"{basicRoute}?afterId={afterId}");
            if(response.OK)
            {
                return response.Data;
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await webRequest.GetAsync<User>($"{basicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<User>> SearchUsersAsync(string name, int afterId = 0)
        {
            var response = await webRequest.GetAsync<List<User>>($"{basicRoute}/search?name={name}&aftedId={afterId}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}