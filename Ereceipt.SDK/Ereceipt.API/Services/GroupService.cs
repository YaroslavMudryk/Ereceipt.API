using Ereceipt.API.Models;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class GroupService : IGroupService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        public GroupService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(urls.Group, accessToken, 10);
        }

        public async Task<Group> GetGroupByIdAsync(Guid id)
        {
            var response = await webRequest.GetAsync<Group>($"{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<Group>> GetMyGroupsAsync()
        {
            var response = await webRequest.GetAsync<List<Group>>("my");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}