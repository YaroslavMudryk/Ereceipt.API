using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Models.Helpers
{
    public class ReceiptGroupModel
    {
        public ReceiptGroupModel(Guid receiptId, Guid groupId)
        {
            ReceiptId = receiptId;
            GroupId = groupId;
        }

        public Guid ReceiptId { get; }
        public Guid GroupId { get; }
    }
}