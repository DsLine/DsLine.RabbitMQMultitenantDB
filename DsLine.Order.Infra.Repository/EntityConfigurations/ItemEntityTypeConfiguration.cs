using DsLine.Orders.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DsLine.Orders.Infra.Repository.EntityConfigurations
{
    public class ItemEntityTypeConfiguration
     : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.Name);


            builder.HasData
               (
                   new Item
                   {
                       Id = new Guid("c724d893-d947-421c-b2e2-a1302e29916c"),
                       Name = "Box"
                   },
                   new Item
                   {
                       Id = new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"),
                       Name = "BoxSmall"

                   },
                   new Item
                   {
                       Id = new Guid("ffe6348d-ee41-451a-97aa-619e4eb7eb76"),
                       Name = "BigSmall"
                   }
               );

        }
    }
}
