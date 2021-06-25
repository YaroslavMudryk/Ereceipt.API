using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<Budget> CreateBudgetAsync(CreateBudgetModel model);
        Task<Budget> EditBudgetAsync(EditBudgetModel model);
        Task<Budget> RemoveBudgetAsync(long id);
        Task<Budget> AddReceiptToBudgetAsync(BudgetReceiptCreateModel model);
        Task<Budget> RemoveReceiptFromBudgetAsync(BudgetReceiptCreateModel model);
    }
}