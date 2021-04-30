﻿using Ereceipt.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
    }
}
