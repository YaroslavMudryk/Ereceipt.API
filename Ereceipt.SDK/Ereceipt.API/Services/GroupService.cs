using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class GroupService : IGroupService
    {
        private WebRequest webRequest;
        private string basicRoute { get; }
        public GroupService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Groups.Basic;
        }

        public WebRequest WebRequest => webRequest;

        public async Task<Group> CreateGroupAsync(CreateGroupModel model)
        {
            var response = await webRequest.PostAsync<Group>(basicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Group> EditGroupAsync(EditGroupModel model)
        {
            var response = await webRequest.PutAsync<Group>(basicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Group> GetGroupByIdAsync(Guid id)
        {
            var response = await webRequest.GetAsync<Group>($"{basicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<GroupMember>> GetGroupMembersById(Guid id)
        {
            var response = await webRequest.GetAsync<List<GroupMember>>($"{basicRoute}/{id}/members");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<Group>> GetMyGroupsAsync()
        {
            var response = await webRequest.GetAsync<List<Group>>($"{basicRoute}/my");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<Receipt>> GetReceiptsByGroupId(Guid id, int skip = 0)
        {
            var response = await webRequest.GetAsync<List<Receipt>>($"{basicRoute}/{id}/receipts");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Group> RemoveGroupAsync(Guid id)
        {
            var response = await webRequest.DeleteAsync<Group>($"{basicRoute}?id={id}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}