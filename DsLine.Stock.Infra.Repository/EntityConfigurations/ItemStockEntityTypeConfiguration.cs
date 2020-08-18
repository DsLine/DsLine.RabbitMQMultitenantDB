using DsLine.Stock.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DsLine.Stock.Infra.Repository.EntityConfigurations
{

    public class ItemStockEntityTypeConfiguration
     : IEntityTypeConfiguration<ItemStock>
    {
        public void Configure(EntityTypeBuilder<ItemStock> builder)
        {
            builder.ToTable("ItemStock");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.Quantity)
                .IsRequired();

            builder.Property(cb => cb.TackingDate)
              .IsRequired();


            builder.HasData
               (
                   new ItemStock
                   {
                       Id = Guid.NewGuid(),
                       ItemId = new Guid("c724d893-d947-421c-b2e2-a1302e29916c"),
                       Quantity = 40,
                       TackingDate = DateTime.Now
                   },
                   new ItemStock
                   {
                       Id = Guid.NewGuid(),
                       ItemId = new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"),
                       Quantity = 23,
                       TackingDate = DateTime.Now
                   },
                   new ItemStock
                   {
                       Id = Guid.NewGuid(),
                       ItemId= new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"),
                       Quantity = 45,
                       TackingDate = DateTime.Now
                   }
               ); 


        }
    }
}
