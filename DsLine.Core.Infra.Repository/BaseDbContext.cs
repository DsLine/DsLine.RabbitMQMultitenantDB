using DShop.CrossCutting.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DsLine.Core.Infra.Repository
{
    public class BaseDbContext : DbContext
    {

        private readonly ITenant _tenant;
        private readonly IHostingEnvironment _hostingEnvironment;
        public BaseDbContext(ITenant tenant, IHostingEnvironment  hostingEnvironment)
        {
            _tenant = tenant;
            _hostingEnvironment = hostingEnvironment;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //if (_tenant is null)
            //{
            //    // get the configuration from the app settings
            //    var config = new ConfigurationBuilder()
            //        .SetBasePath(Directory.GetCurrentDirectory())
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //    // define the database to use
            //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //}
            //else
            //{

            //    optionsBuilder.UseSqlServer(_tenant.TenantId);
            //    // optionsBuilder.UseSqlServer("Server=DESKTOP-9HSNFN5;Database=DsLine_Order_tenant1;User Id=sa; Password=adwsx46852+-;");
            //}

            var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json", optional: true)
                  .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetSection("ConnectionStrings").Value);

        }
    }
}
