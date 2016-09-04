using System.Collections.Generic;
using AzureWorkshop.Models;

namespace AzureWorkshop.Controllers.Home
{
    public class HomeViewModel
    {
        public HomeViewModel(string pageTitle, List<Exchange> exchanges)
        {
            PageTitle = pageTitle;
            Exchanges = exchanges;
        }

        public string PageTitle { get; set; }
        public List<Exchange> Exchanges { get; set; }
    }
}