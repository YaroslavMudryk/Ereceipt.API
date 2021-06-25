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
        private string basicRoute { get; }
        public CurrencyService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Currencies.Basic;
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            var response = await webRequest.GetAsync<List<Currency>>(basicRoute);
            if (response.OK)
                return response.Data;
            return default;
        }
    }
}