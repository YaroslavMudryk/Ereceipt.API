using Ereceipt.API.Models;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ereceipt.API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        public string BasicRoute { get; }
        public CurrencyService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
            BasicRoute = ApiRoutes.V1.Currencies.Basic;
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            var response = await webRequest.GetAsync<List<Currency>>(BasicRoute);
            if (response.OK)
                return response.Data;
            return default;
        }
    }
}