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
            var receipt = await client.ReceiptService.GetReceiptByIdAsync(receiptId);
            Console.WriteLine($"Id:{receipt.Id}, Shop:{receipt.ShopName}, User:{receipt.User.Name}, Sum:{receipt.TotalPrice}");
            var comments = await client.ReceiptService.GetCommentsByReceiptIdAsync(receiptId);
            Console.WriteLine($"Id:{comments[0].Id} - {comments[0].Text} from {comments[0].User.Name}");
        }
    }
}
