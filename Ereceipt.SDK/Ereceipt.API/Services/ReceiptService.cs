using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class ReceiptService : IReceiptService
    {
        private WebRequest webRequest;
        private string basicRoute { get; }
        public ReceiptService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Receipts.Basic;
        }

        public async Task<Receipt> AddReceiptToGroupAsync(ReceiptGroupModel model)
        {
            var response = await webRequest.PostAsync<Receipt>($"{basicRoute}/to-group", model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> CreateReceiptAsync(CreateReceiptModel receipt)
        {
            var response = await webRequest.PostAsync<Receipt>($"{basicRoute}", receipt);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> EditReceiptAsync(EditReceiptModel receipt)
        {
            var response = await webRequest.PutAsync<Receipt>($"{basicRoute}", receipt);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<List<Comment>> GetCommentsByReceiptIdAsync(Guid id)
        {
            var response = await webRequest.GetAsync<List<Comment>>($"{basicRoute}/{id}/comments");
            if (response.OK)
                return response.Data;
            return default;
        }

        public async Task<int> GetCountOfMyReceiptsAsync()
        {
            var response = await webRequest.GetAsync<int>($"{basicRoute}/my/count");
            if (response.OK)
                return response.Data;
            return default;
        }

        public async Task<List<Receipt>> GetMyReceiptsAsync(int offset)
        {
            var response = await webRequest.GetAsync<List<Receipt>>($"{basicRoute}/my?skip={offset}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> GetReceiptByIdAsync(Guid id)
        {
            var response = await webRequest.GetAsync<Receipt>($"{basicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> RemoveReceiptAsync(Guid id)
        {
            var response = await webRequest.DeleteAsync<Receipt>($"{basicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Receipt> RemoveReceiptFromGroupAsync(ReceiptGroupModel model)
        {
            var response = await webRequest.PostAsync<Receipt>($"{basicRoute}/from-group", model);
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}