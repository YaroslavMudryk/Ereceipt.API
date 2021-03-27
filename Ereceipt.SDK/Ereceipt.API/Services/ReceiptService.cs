using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class ReceiptService : IReceiptService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        public ReceiptService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
        }

        public async Task<Receipt> AddReceiptToGroupAsync(ReceiptGroupModel model)
        {
            var response = await webRequest.PostAsync<Receipt>(urls.Receipts+ "/togroup", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> CreateReceiptAsync(CreateReceiptModel receipt)
        {
            var response = await webRequest.PostAsync<Receipt>(urls.Receipts, receipt);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> EditReceiptAsync(EditReceiptModel receipt)
        {
            var response = await webRequest.PutAsync<Receipt>(urls.Receipts, receipt);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<int> GetCountOfMyReceiptsAsync()
        {
            var response = await webRequest.GetAsync<int>(urls.Receipts + "/my/count");
            if (response.OK)
                return response.Data;
            return default;
        }

        public async Task<List<Receipt>> GetMyReceiptsAsync(int skip)
        {
            var response = await webRequest.GetAsync<List<Receipt>>(urls.Receipts + "/my");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> GetReceiptByIdAsync(Guid id)
        {
            var response = await webRequest.GetAsync<Receipt>(urls.Receipts + $"/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> RemoveReceiptAsync(Guid id)
        {
            var response = await webRequest.DeleteAsync<Receipt>(urls.Receipts + $"/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> RemoveReceiptFromGroupAsync(ReceiptGroupModel model)
        {
            var response = await webRequest.PostAsync<Receipt>(urls.Receipts + "/fromgroup", model);
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}