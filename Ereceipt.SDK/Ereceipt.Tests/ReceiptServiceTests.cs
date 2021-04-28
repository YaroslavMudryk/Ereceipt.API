using Ereceipt.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ereceipt.Tests
{
    public class ReceiptServiceTests
    {
        private IReceiptClient client;

        #region Read
        [Fact]
        public void GetReceiptById()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var receipt = client.ReceiptService.GetReceiptByIdAsync(Guid.Parse("58880cf8-c2af-434f-0fdd-08d8f434a702")).Result;
            Assert.NotNull(receipt);
        }

        [Fact]
        public void GetCommentsByReceipt()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var comments = client.ReceiptService.GetCommentsByReceiptIdAsync(Guid.Parse("58880cf8-c2af-434f-0fdd-08d8f434a702")).Result;
            Assert.Equal(3, comments.Count);
        }

        [Fact]
        public void GetMyReceipts()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var receipts = client.ReceiptService.GetMyReceiptsAsync(0).Result;
            Assert.NotNull(receipts);
        }

        [Fact]
        public void CheckMyReceiptsCount()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var receipts = client.ReceiptService.GetCountOfMyReceiptsAsync().Result;
            Assert.Equal(4, receipts);
        }
        #endregion

        private Guid Id { get; set; } = Guid.NewGuid();

        #region Write
        [Fact]
        public void CreateReceipt()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var receipt = client.ReceiptService.CreateReceiptAsync(new API.Models.Helpers.CreateReceiptModel
            {
                IsImportant = false,
                ShopName = "Silpo",
                Products = new List<API.Models.Helpers.CreateProductModel>
                {
                    new API.Models.Helpers.CreateProductModel
                    {
                        CountWeight = 1,
                        Id = Guid.NewGuid().ToString("N"),
                        Name = "Product_12",
                        Price = 12.99
                    }
                }
            }).Result;
            Id = receipt.Id;
            Assert.NotNull(receipt);
        }

        [Fact]
        public void EditReceipt()
        {
            client = new EreceiptClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFyb3NsYXYubXVkcnlrQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiSWQiOiIxIiwibmJmIjoxNjE4NjgzNTY5LCJleHAiOjE2MTk5Nzk1NjksImlzcyI6IkVyZWNlaXB0U2VydmVyIiwiYXVkIjoiRXJlY2VpcHRDbGllbnQifQ.UX9nqvvaRSk9nwUdApfy6euLMeOddlHqUUIarXFibW4");
            var receipt = client.ReceiptService.EditReceiptAsync(new API.Models.Helpers.EditReceiptModel
            {
                Id = Id,
                IsImportant = true,
                ShopName = "Сільпо",
                Products = new List<API.Models.Helpers.CreateProductModel>
                {
                    new API.Models.Helpers.CreateProductModel
                    {
                        CountWeight = 1,
                        Id = Guid.NewGuid().ToString("N"),
                        Name = "Product_12356",
                        Price = 12.99
                    }
                }
            }).Result;
            Assert.Equal(12.99, receipt.Products[0].Price);
        }
        #endregion
    }
}