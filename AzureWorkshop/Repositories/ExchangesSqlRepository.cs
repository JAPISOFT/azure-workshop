using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AzureWorkshop.Models;
using AzureWorkshop.Repositories.Interfaces;
using AzureWorkshop.Services.Interfaces;

namespace AzureWorkshop.Repositories
{
    public class ExchangesSqlRepository : IExchangesRepository
    {
        private readonly IExchangeService _exchangeService;
        private readonly AppContext _db;

        public ExchangesSqlRepository(IExchangeService exchangeService, AppContext db)
        {
            _exchangeService = exchangeService;
            _db = db;
        }

        public async Task<List<Exchange>> GetExchangesAsync(DateTime date)
        {
            var exchanges = await _db.Exchanges.AsNoTracking().Where(x => x.Date == date).Select(x =>
                new Exchange
                {
                    Amount = x.Amount,
                    ExchangeRate = x.ExchangeRate,
                    Code = x.Code,
                    Currency = x.Currency,
                    Country = x.Country
                }).ToListAsync();

            if (exchanges.Count > 0)
            {
                return exchanges;
            }

            exchanges = await _exchangeService.GetExchangesAsync(date);
            foreach (var exchange in exchanges)
            {
                _db.Exchanges.Add(new CnbExchange
                {
                    Date = date.Date,
                    Amount = exchange.Amount,
                    ExchangeRate = exchange.ExchangeRate,
                    Code = exchange.Code,
                    Currency = exchange.Currency,
                    Country = exchange.Country
                });
            }
            await _db.SaveChangesAsync();

            return exchanges;
        }
    }
}