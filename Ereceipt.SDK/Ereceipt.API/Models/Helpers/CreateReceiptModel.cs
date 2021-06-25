using System;
using System.Collections.Generic;
namespace Ereceipt.API.Models.Helpers
{
    public class CreateReceiptModel
    {
        public string ShopName { get; set; }
        public bool IsImportant { get; set; }
        public Guid? GroupId { get; set; }
        public int? CurrencyId { get; set; }
        public List<CreateProductModel> Products { get; set; }
    }
}