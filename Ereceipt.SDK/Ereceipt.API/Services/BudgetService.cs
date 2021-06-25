using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly WebRequest webRequest;
        private string basicRoute { get; }
        public BudgetService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Budgets.Basic;
        }

        public async Task<Budget> CreateBudgetAsync(CreateBudgetModel model)
        {
            var response = await webRequest.PostAsync<Budget>(basicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> EditBudgetAsync(EditBudgetModel model)
        {
            var response = await webRequest.PutAsync<Budget>(basicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> RemoveBudgetAsync(long id)
        {
            var response = await webRequest.DeleteAsync<Budget>(basicRoute + "/" + id.ToString());
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> AddReceiptToBudgetAsync(BudgetReceiptCreateModel model)
        {
            var response = await webRequest.PostAsync<Budget>(basicRoute + "/receipt", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> RemoveReceiptFromBudgetAsync(BudgetReceiptCreateModel model)
        {
            var response = await webRequest.DeleteAsync<Budget>(basicRoute + "/receipt", model);
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}