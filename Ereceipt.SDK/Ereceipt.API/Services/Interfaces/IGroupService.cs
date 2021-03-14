using Ereceipt.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<Group>> GetMyGroupsAsync();
        Task<Group> GetGroupByIdAsync(Guid id);
        Task<List<GroupMember>> GetGroupMembersById(Guid id);
        Task<List<Receipt>> GetReceiptsByGroupId(Guid id, int skip = 0);
    }
}