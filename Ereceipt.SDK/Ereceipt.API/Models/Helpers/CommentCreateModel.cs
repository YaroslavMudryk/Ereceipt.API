using System;
namespace Ereceipt.API.Models.Helpers
{
    public class CommentCreateModel
    {
        public string Text { get; set; }
        public Guid ReceiptId { get; set; }
    }
}