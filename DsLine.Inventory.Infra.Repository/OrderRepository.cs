using DsLine.Inventory.Models.Entities;

namespace DsLine.Inventory.Infra.Repository
{
    public class OrderRepository : Repository<Item>
    {
        public OrderRepository(InventoryDbContext inventoryDbContext) : base(inventoryDbContext)
        {

        }
    }
}
