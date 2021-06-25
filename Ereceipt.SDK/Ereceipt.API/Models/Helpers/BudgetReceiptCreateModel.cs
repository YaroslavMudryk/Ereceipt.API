using System;

namespace Ereceipt.API.Models.Helpers
{
    public class BudgetReceiptCreateModel
    {
        public long BudgetId { get; set; }
        public Guid ReceiptId { get; set; }
    }
}