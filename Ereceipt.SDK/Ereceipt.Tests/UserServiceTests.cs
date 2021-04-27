using Ereceipt.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ereceipt.Tests
{
    public class UserServiceTests
    {
        private IReceiptClient client;

        [Fact]
        public void GetCountUsersTest()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var users = client.UserService.GetAllUsers().Result;
            Assert.Equal(4, users.Count);
        }

        [Fact]
        public void CheckUserRole()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var user = client.UserService.GetUserByIdAsync(1).Result;
            Assert.Equal("Admin", user.Role);
        }
    }
}