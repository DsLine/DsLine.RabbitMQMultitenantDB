using DShop.CrossCutting.MultiTenant;
using DsLine.Core.Infra.Repository;
using DsLine.Stock.Infra.Repository.EntityConfigurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DsLine.Stock.Infra.Repository
{
    public class StockDbContext : BaseDbContext
    {

        public StockDbContext(ITenant tenant, IHostingEnvironment hostingEnvironment) : base(tenant, hostingEnvironment)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemStockEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
