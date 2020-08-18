using DsLine.Stock.Models.Entities;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DsLine.Stock.Infra.Repository
{
    public class ItemRepository : Repository<ItemStock>, IItemRepository
    {
        public ItemRepository(StockDbContext stockDbContext) : base(stockDbContext)
        {

        }

        public ItemStock GetByItem(Guid itemId)
        {
            return DbSet.Where(x => x.ItemId == itemId).SingleOrDefault();
        }
    }
}

