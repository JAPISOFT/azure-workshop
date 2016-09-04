using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureWorkshop.Models
{
    public class Exchange
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string Code { get; set; }
        public decimal ExchangeRate { get; set; } 
    }
}