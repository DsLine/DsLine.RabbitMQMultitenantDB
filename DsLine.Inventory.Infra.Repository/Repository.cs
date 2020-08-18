using DsLine.Core.Infra.Repository;

namespace DsLine.Inventory.Infra.Repository
{
    public class Repository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        public Repository(InventoryDbContext inventoryDbContext) : base(inventoryDbContext)
        {

        }
    }
}
