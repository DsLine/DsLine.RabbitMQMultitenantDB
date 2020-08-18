using DShop.CrossCutting.MultiTenant;
using DsLine.Core.Infra.Repository;
using DsLine.Orders.Infra.Repository.EntityConfigurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DsLine.Orders.Infra.Repository
{
    public class OrderDbContext : BaseDbContext
    {
        public OrderDbContext(ITenant tenant, IHostingEnvironment hostingEnvironment) : base(tenant, hostingEnvironment)
        {
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
