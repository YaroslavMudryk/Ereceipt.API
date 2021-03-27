using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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