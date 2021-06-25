using Ereceipt.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
    }
}