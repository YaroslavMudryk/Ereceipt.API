using Ereceipt.API;
using Ereceipt.API.Models.Helpers;
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
            var token = await client.IdentityService.LoginUserAsync(new LoginUserModel("yaroslav.mudryk@gmail.com", "SomePassword"));
            client.AuthorizeUser(token);
            var myGroups = await client.GroupService.GetMyGroupsAsync();
            var group = await client.GroupService.GetGroupByIdAsync(myGroups[0].Id);
            var members = await client.GroupService.GetGroupMembersById(myGroups[0].Id);
            var users = await client.UserService.GetAllUsers();
            var users2 = await client.UserService.GetAllUsers(1);
        }
    }
}
