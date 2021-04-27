using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Models.Helpers
{
    public class CommentCreateModel
    {
        public string Text { get; set; }
        public Guid ReceiptId { get; set; }
    }
}