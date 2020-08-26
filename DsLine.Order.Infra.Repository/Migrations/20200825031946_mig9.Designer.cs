﻿// <auto-generated />
using System;
using DsLine.Orders.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DsLine.Orders.Infra.Repository.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20200825031946_mig9")]
    partial class mig9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DsLine.Orders.Models.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aac5005f-cbc8-4331-bfa3-d4cac80e15e6"),
                            Name = "Carlos"
                        },
                        new
                        {
                            Id = new Guid("4b00dfa5-d1e2-4d61-98f8-d80efbff197b"),
                            Name = "Rober"
                        },
                        new
                        {
                            Id = new Guid("8cc36f87-02e6-460a-9bef-43853e192a14"),
                            Name = "Peter"
                        });
                });

            modelBuilder.Entity("DsLine.Orders.Models.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c724d893-d947-421c-b2e2-a1302e29916c"),
                            Name = "Box"
                        },
                        new
                        {
                            Id = new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"),
                            Name = "BoxSmall"
                        },
                        new
                        {
                            Id = new Guid("ffe6348d-ee41-451a-97aa-619e4eb7eb76"),
                            Name = "BigSmall"
                        });
                });

            modelBuilder.Entity("DsLine.Orders.Models.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DsLine.Orders.Models.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("OrdersItem");
                });

            modelBuilder.Entity("DsLine.Orders.Models.Entities.OrderItem", b =>
                {
                    b.HasOne("DsLine.Orders.Models.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("Id");
                });
#pragma warning restore 612, 618
        }
    }
}
