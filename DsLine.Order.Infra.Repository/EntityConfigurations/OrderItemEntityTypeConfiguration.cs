using DsLine.Orders.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsLine.Orders.Infra.Repository.EntityConfigurations
{
    class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrdersItem");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.ItemId)
                .IsRequired();

            builder.Property(cb => cb.Quantity)
           .IsRequired();




        }
    }
}
