using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureWorkshop.Models;

namespace AzureWorkshop.Repositories.Interfaces
{
    public interface IExchangesRepository
    {
        Task<List<Exchange>> GetExchangesAsync(DateTime date);
    }
}