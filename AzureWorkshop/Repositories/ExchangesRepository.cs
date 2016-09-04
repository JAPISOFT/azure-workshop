using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureWorkshop.Models;
using AzureWorkshop.Repositories.Interfaces;
using AzureWorkshop.Services.Interfaces;

namespace AzureWorkshop.Repositories
{
    public class ExchangesRepository : IExchangesRepository
    {
        private readonly IExchangeService _exchangeService;

        public ExchangesRepository(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        public async Task<List<Exchange>> GetExchangesAsync(DateTime date)
        {
            var exchanges = await _exchangeService.GetExchangesAsync(date);

            return exchanges;
        }
    }
}