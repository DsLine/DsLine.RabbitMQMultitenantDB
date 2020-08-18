using DShop.CrossCutting.MultiTenant;
using DsLine.Core.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace DsLine.Inventory.Infra.Repository
{
    public class InventoryDbContext : BaseDbContext
    {
        public InventoryDbContext(ITenant tenant):base(tenant)
        { 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
