using Ereceipt.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ereceipt.Tests
{
    public class CommentServiceTests
    {
        private IReceiptClient client;
        [Fact]
        public void GetCommentByIdTest()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var comment = client.CommentService.GetCommentByIdAsync(10).Result;
            Assert.NotNull(comment);
        }
    }
}