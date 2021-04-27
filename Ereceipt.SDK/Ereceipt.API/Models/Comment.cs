using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Receipt Receipt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}