using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<Receipt> CreateReceiptAsync(CreateReceiptModel receipt);
        Task<Receipt> EditReceiptAsync(EditReceiptModel receipt);
        Task<Receipt> RemoveReceiptAsync(Guid id);
        Task<Receipt> GetReceiptByIdAsync(Guid id);
        Task<List<Receipt>> GetMyReceiptsAsync(int offset);
        Task<List<Comment>> GetCommentsByReceiptIdAsync(Guid id);
        Task<int> GetCountOfMyReceiptsAsync();
        Task<Receipt> AddReceiptToGroupAsync(ReceiptGroupModel model);
        Task<Receipt> RemoveReceiptFromGroupAsync(ReceiptGroupModel model);
    }
}