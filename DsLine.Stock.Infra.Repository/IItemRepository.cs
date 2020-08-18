using DsLine.Core.Infra.Repository;
using DsLine.Stock.Models.Entities;
using System;

namespace DsLine.Stock.Infra.Repository
{
    public interface IItemRepository: IBaseRepository<ItemStock>
    {
        ItemStock GetByItem(Guid itemId);
    }
}

