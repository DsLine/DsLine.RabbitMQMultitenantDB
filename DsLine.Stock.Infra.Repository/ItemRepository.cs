using DsLine.Stock.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool UpdateStock(List<ItemStock> itemStocksUpdates)
        {
            var listItemIdId = itemStocksUpdates.Select(r => r.ItemId);
            List<ItemStock> itemStocks = DbSet.Where(r => listItemIdId.Contains(r.ItemId)).ToList();
            foreach (var item in itemStocks)
            {
                ItemStock itemStockUpdate = itemStocksUpdates.Where(x => x.ItemId == item.ItemId).SingleOrDefault();
                item.Quantity = item.Quantity - itemStockUpdate.Quantity;
                DbSet.Update(item);
            }
            DbContext.SaveChanges();


            return true;
        }
    }
}

