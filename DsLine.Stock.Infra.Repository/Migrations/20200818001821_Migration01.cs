using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DsLine.Stock.Infra.Repository.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "ItemStock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "ItemStock",
                columns: new[] { "Id", "ItemId", "Quantity", "TackingDate" },
                values: new object[] { new Guid("36d8bea0-c60e-45e6-b6ac-f3823d97dd94"), new Guid("c724d893-d947-421c-b2e2-a1302e29916c"), 40, new DateTime(2020, 8, 17, 21, 18, 21, 369, DateTimeKind.Local).AddTicks(3680) });

            migrationBuilder.InsertData(
                table: "ItemStock",
                columns: new[] { "Id", "ItemId", "Quantity", "TackingDate" },
                values: new object[] { new Guid("de29b980-c05e-41e3-8255-d0c5038beb0c"), new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"), 23, new DateTime(2020, 8, 17, 21, 18, 21, 370, DateTimeKind.Local).AddTicks(3643) });

            migrationBuilder.InsertData(
                table: "ItemStock",
                columns: new[] { "Id", "ItemId", "Quantity", "TackingDate" },
                values: new object[] { new Guid("7030d504-b209-4c99-874b-556abd88bdf2"), new Guid("639a9b9d-f092-44a3-ba36-680d86454be1"), 45, new DateTime(2020, 8, 17, 21, 18, 21, 370, DateTimeKind.Local).AddTicks(3668) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemStock",
                keyColumn: "Id",
                keyValue: new Guid("36d8bea0-c60e-45e6-b6ac-f3823d97dd94"));

            migrationBuilder.DeleteData(
                table: "ItemStock",
                keyColumn: "Id",
                keyValue: new Guid("7030d504-b209-4c99-874b-556abd88bdf2"));

            migrationBuilder.DeleteData(
                table: "ItemStock",
                keyColumn: "Id",
                keyValue: new Guid("de29b980-c05e-41e3-8255-d0c5038beb0c"));

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemStock");
        }
    }
}
