using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureWorkshop.Models;

namespace AzureWorkshop.Services.Interfaces
{
    public interface IExchangeService
    {
        Task<List<Exchange>> GetExchangesAsync(DateTime date);
    }
}