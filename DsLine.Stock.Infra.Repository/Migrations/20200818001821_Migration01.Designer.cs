﻿// <auto-generated />
using System;
using DsLine.Stock.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DsLine.Stock.Infra.Repository.Migrations
{
    [DbContext(typeof(StockDbContext))]
    [Migration("20200818001821_Migration01")]
    partial class Migration01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DsLine.Stock.Models.Entities.ItemStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TackingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ItemStock");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36d8bea0-c60e-45e6-b6ac-f3823d97dd94"),
                            ItemId = new Guid("c724d893-d947-421c-b2e2-a1302e29916c"),
                            Quantity = 40,
                            TackingDate = new DateTime(2020, 8, 17, 21, 18, 21, 369, DateTimeKind.Local).AddTicks(3680)
                        },
                        new
                        {
                            Id = new Guid("de29b980-c05e-41e3-8255-d0c5038beb0c"),
                            ItemId = new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"),
                            Quantity = 23,
                            TackingDate = new DateTime(2020, 8, 17, 21, 18, 21, 370, DateTimeKind.Local).AddTicks(3643)
                        },
                        new
                        {
                            Id = new Guid("7030d504-b209-4c99-874b-556abd88bdf2"),
                            ItemId = new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"),
                            Quantity = 45,
                            TackingDate = new DateTime(2020, 8, 17, 21, 18, 21, 370, DateTimeKind.Local).AddTicks(3668)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
