using System;
using System.Collections.Generic;
namespace Ereceipt.API.Models.Helpers
{
    public class EditReceiptModel
    {
        public Guid Id { get; set; }
        public string ShopName { get; set; }
        public bool IsImportant { get; set; }
        public List<CreateProductModel> Products { get; set; }
    }
}