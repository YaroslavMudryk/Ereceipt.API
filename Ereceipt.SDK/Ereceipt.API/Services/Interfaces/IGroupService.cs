using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface IGroupService
    {
        Task<Group> CreateGroupAsync(CreateGroupModel model);
        Task<Group> EditGroupAsync(EditGroupModel model);
        Task<Group> RemoveGroupAsync(Guid id);
        Task<List<Group>> GetMyGroupsAsync();
        Task<Group> GetGroupByIdAsync(Guid id);
        Task<List<GroupMember>> GetGroupMembersById(Guid id);
        Task<List<Receipt>> GetReceiptsByGroupId(Guid id, int skip = 0);
    }
}