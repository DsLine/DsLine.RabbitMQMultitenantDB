using DsLine.Orders.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DsLine.Orders.Infra.Repository.EntityConfigurations
{
    public class CustomerEntityTypeConfiguration
      : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.Name);


            builder.HasData
            (
                new Item
                {
                    Id = new Guid("aac5005f-cbc8-4331-bfa3-d4cac80e15e6"),
                    Name = "Carlos"
                },
                new Item
                {
                    Id = new Guid("4b00dfa5-d1e2-4d61-98f8-d80efbff197b"),
                    Name = "Rober"

                },
                new Item
                {
                    Id = new Guid("8cc36f87-02e6-460a-9bef-43853e192a14"),
                    Name = "Peter"
                }
            );

        }
    }
}
