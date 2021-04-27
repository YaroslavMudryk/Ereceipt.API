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
            var receiptId = Guid.Parse("58880cf8-c2af-434f-0fdd-08d8f434a702");
            var client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            //await client.LoginAsync(new LoginUserModel("yaroslav.mudryk@gmail.com", "SomePassword"));
            //var myGroups = await client.GroupService.GetMyGroupsAsync();
            //var myReceipts = await client.ReceiptService.GetMyReceiptsAsync(0);
            var receipt = await client.ReceiptService.GetReceiptByIdAsync(receiptId);
            var comments = await client.ReceiptService.GetCommentsByReceiptIdAsync(receiptId);
            //var group = await client.GroupService.GetGroupByIdAsync(myGroups[0].Id);
            //var members = await client.GroupService.GetGroupMembersById(myGroups[0].Id);
            //var user = await client.UserService.GetUserByIdAsync(1);
            //var users = await client.UserService.GetAllUsers();
            //var users2 = await client.UserService.GetAllUsers(1);
        }
    }
}
