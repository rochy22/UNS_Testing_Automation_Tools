using Common;
using FmsDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FMSWebPortal.Shared
{
    public class FmsContextHelper
    {
        public static FmsContext CreateFmsContext()
        {
            IConfiguration _configuration = ConfigurationReader.GetInstance();

            var connectionString = _configuration["FmsContext:ConnectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<FmsContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new FmsContext(optionsBuilder.Options);
        }
    }
}
