using AzureWorkshop.Models;
using AzureWorkshop.Repositories;
using AzureWorkshop.Repositories.Interfaces;
using AzureWorkshop.Services;
using AzureWorkshop.Services.Interfaces;
using Ninject;
using Ninject.Web.Common;

namespace AzureWorkshop
{
    public static class IoC
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<AppContext>().ToSelf().InRequestScope();
            kernel.Bind<IExchangeService>().To<CnbService>().InRequestScope();
            kernel.Bind<IExchangesRepository>().To<ExchangesRepository>().InRequestScope();
        }
    }
}