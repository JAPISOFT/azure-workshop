using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AzureWorkshop.Repositories.Interfaces;

namespace AzureWorkshop.Controllers.Home
{
    public class HomeController : AsyncController
    {
        private readonly IExchangesRepository _exchangesRepository;

        public HomeController(IExchangesRepository exchangesRepository)
        {
            _exchangesRepository = exchangesRepository;
        }

        public async Task<ActionResult> Index(DateTime? date)
        {
            if (date == null)
            {
                date = DateTime.Now;
            }

            var viewModel = new HomeViewModel(_exchangesRepository.GetType().Name, await _exchangesRepository.GetExchangesAsync(date.Value));

            return View(viewModel);
        }
    }
}