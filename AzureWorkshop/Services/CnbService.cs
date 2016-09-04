using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AzureWorkshop.Logging;
using AzureWorkshop.Models;
using AzureWorkshop.Services.Interfaces;

namespace AzureWorkshop.Services
{
    public class CnbService : IExchangeService
    {
        private const string ExchangesUrl = "http://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt?date={0}.{1}.{2}";

        public async Task<List<Exchange>> GetExchangesAsync(DateTime date)
        {
            string url = string.Format(ExchangesUrl, date.Day, date.Month, date.Year);
            string data = await DownloadTextAsync(url);

            List<Exchange> exchanges = new List<Exchange>();
            using (StringReader stringReader = new StringReader(data))
            {
                while (true)
                {
                    string line = stringReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    Exchange exchange;
                    if (TryParseExchangeFromString(line, out exchange))
                    {
                        exchanges.Add(exchange);
                    }
                }
            }

            return exchanges;
        }

        protected virtual async Task<string> DownloadTextAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return await Task.FromResult(default(string));
            }

            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                return await webClient.DownloadStringTaskAsync(new Uri(url));
            }
        }
        private bool TryParseExchangeFromString(string input, out Exchange exchange)
        {
            exchange = null;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            string[] parameters = input.Split('|');
            if (parameters.Length != 5)
            {
                return false;
            }

            try
            {
                exchange = new Exchange
                {
                    Country = parameters[0],
                    Currency = parameters[1],
                    Amount = decimal.Parse(parameters[2]),
                    Code = parameters[3],
                    ExchangeRate = decimal.Parse(parameters[4])
                };

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);

                return false;
            }
        }
    }
}