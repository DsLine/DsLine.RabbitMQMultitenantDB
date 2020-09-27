using DsLine.Core.Infra.Repository;
using DsLine.Stock.Models.Entities;
using System;
using System.Collections.Generic;

namespace DsLine.Stock.Infra.Repository
{
    public interface IItemRepository : IBaseRepository<ItemStock>
    {
        ItemStock GetByItem(Guid itemId);

        bool UpdateStock(List<ItemStock> list);
    }
}

