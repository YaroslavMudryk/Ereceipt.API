using Ereceipt.API;
using Ereceipt.API.Services;
using System;
using System.Threading.Tasks;

namespace EreceiptExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new EreceiptClient();
            var group = await client.GroupService.GetGroupByIdAsync(Guid.Parse("4e762d73-8d82-47bb-26c0-08d8e6cf4c3d"));
            var myGroups = await client.GroupService.GetMyGroupsAsync();
            var members = await client.GroupService.GetGroupMembersById(new Guid("4e762d73-8d82-47bb-26c0-08d8e6cf4c3d"));
            var users = await client.UserService.GetAllUsers();
            var users2 = await client.UserService.GetAllUsers(1);
        }
    }
}
