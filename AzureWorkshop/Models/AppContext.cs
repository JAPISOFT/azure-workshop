using System.Data.Entity;

namespace AzureWorkshop.Models
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            
        }

        public DbSet<CnbExchange> Exchanges { get; set; }
    }
}