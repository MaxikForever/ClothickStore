using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class ProductTitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("05795a24-d716-4d25-a193-21f7d056f962"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b018b906-4197-4397-927c-d11176efdc1b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6f0ee4a-ac87-4575-bdad-0a4558a0302a"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("26ec1514-d900-47e9-90b3-fdab6b076042"), "98bd7950-ba67-476c-a1f1-bd111c87d272", "Guest", "GUEST" },
                    { new Guid("687f645b-c302-417b-af24-1ad28603047c"), "5e3e923e-882d-4875-bd2a-782ab0f79fb1", "Admin", "ADMIN" },
                    { new Guid("694d9532-f247-4e0a-ab97-e735fce5f8d1"), "938d3167-fd91-4320-9065-d582ea0e99d8", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26ec1514-d900-47e9-90b3-fdab6b076042"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("687f645b-c302-417b-af24-1ad28603047c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("694d9532-f247-4e0a-ab97-e735fce5f8d1"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05795a24-d716-4d25-a193-21f7d056f962"), "66295818-6df7-45c6-9193-dbf897bbd5df", "Guest", "GUEST" },
                    { new Guid("b018b906-4197-4397-927c-d11176efdc1b"), "535883eb-a85d-4da6-9432-d93ce8166679", "Admin", "ADMIN" },
                    { new Guid("e6f0ee4a-ac87-4575-bdad-0a4558a0302a"), "cb8e9f4a-f3d9-4cf6-b0bb-04de323a1081", "User", "USER" }
                });
        }
    }
}
