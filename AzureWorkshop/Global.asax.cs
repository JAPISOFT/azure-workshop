using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using AzureWorkshop.Models;
using Microsoft.ApplicationInsights.Extensibility;

namespace AzureWorkshop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // TelemetryConfiguration.Active.InstrumentationKey = "453e6fd6-0ed9-4c78-96a3-3b3833a3d538";

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }
    }
}
