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
    public class GroupService : IGroupService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        public GroupService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(urls.Group, accessToken, 10);
        }

        public WebRequest WebRequest => webRequest;

        public async Task<Group> CreateGroupAsync(CreateGroupModel model)
        {
            var response = await webRequest.PostAsync<Group>(null, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Group> EditGroupAsync(EditGroupModel model)
        {
            var response = await webRequest.PutAsync<Group>(null, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Group> GetGroupByIdAsync(Guid id)
        {
            var response = await webRequest.GetAsync<Group>($"/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<GroupMember>> GetGroupMembersById(Guid id)
        {
            var response = await webRequest.GetAsync<List<GroupMember>>($"/{id}/members");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<Group>> GetMyGroupsAsync()
        {
            var response = await webRequest.GetAsync<List<Group>>("/my");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<Receipt>> GetReceiptsByGroupId(Guid id, int skip = 0)
        {
            var response = await webRequest.GetAsync<List<Receipt>>($"/{id}/receipts");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Group> RemoveGroupAsync(Guid id)
        {
            var response = await webRequest.DeleteAsync<Group>($"?id={id}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}