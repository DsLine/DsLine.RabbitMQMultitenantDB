using DShop.CrossCutting.MultiTenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DsLine.Core.Infra.Repository
{
    public class BaseDbContext : DbContext
    {

        private readonly ITenant _tenant;
        private readonly IHostingEnvironment _hostingEnvironment;
        public BaseDbContext(ITenant tenant, IHostingEnvironment hostingEnvironment)
        {
            _tenant = tenant;
            _hostingEnvironment = hostingEnvironment;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json", optional: true)
             .Build();

            if (_tenant is null)
            {
                optionsBuilder.UseSqlServer(config.GetSection("ConnectionStrings").Value);
            }
            else
            {
                List<TennatConn> tennatConns = config.GetSection("tenants").Get<List<TennatConn>>();
                TennatConn tennatConn = tennatConns.Where(tenant => tenant.tenantId == _tenant.TenantId).SingleOrDefault();
                optionsBuilder.UseSqlServer(tennatConn.connectionstring);
            }


        }
    }

    public class TennatConn
    {
        public string tenantId { get; set; }

        public string connectionstring { get; set; }
    }
}
