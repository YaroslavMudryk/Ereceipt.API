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
        private readonly BaseUrl urls;
        public string BasicRoute { get; }
        public BudgetService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
            BasicRoute = ApiRoutes.V1.Comments.Basic;
        }

        public async Task<Budget> CreateBudgetAsync(CreateBudgetModel model)
        {
            var response = await webRequest.PostAsync<Budget>(BasicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> EditBudgetAsync(EditBudgetModel model)
        {
            var response = await webRequest.PutAsync<Budget>(BasicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> RemoveBudgetAsync(long id)
        {
            var response = await webRequest.DeleteAsync<Budget>(BasicRoute + "/" + id.ToString());
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> AddReceiptToBudgetAsync(BudgetReceiptCreateModel model)
        {
            var response = await webRequest.PostAsync<Budget>(BasicRoute + "/receipt", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Budget> RemoveReceiptFromBudgetAsync(BudgetReceiptCreateModel model)
        {
            var response = await webRequest.DeleteAsync<Budget>(BasicRoute + "/receipt", model);
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}