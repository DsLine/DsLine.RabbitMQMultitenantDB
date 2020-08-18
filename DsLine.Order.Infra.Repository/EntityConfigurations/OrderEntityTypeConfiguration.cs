using DsLine.Orders.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsLine.Orders.Infra.Repository.EntityConfigurations
{
    public class OrderEntityTypeConfiguration
     : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.CustomerId)
                .IsRequired();



            builder.HasMany(o => o.Items).WithOne().HasForeignKey(x => x.Id).IsRequired(false);


        }
    }
}
