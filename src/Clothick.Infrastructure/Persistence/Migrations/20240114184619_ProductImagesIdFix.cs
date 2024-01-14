using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class ProductImagesIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93778b5e-73bc-4c57-94e3-222a5b5eaa7e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dbb88edb-5fd7-425f-af37-4cbd734a8a2b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f43ef6c8-3149-454c-b68f-e26ff24ccda1"));

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "ProductVariants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductVariants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("93778b5e-73bc-4c57-94e3-222a5b5eaa7e"), "83a36950-54f3-42cb-b4af-312cd6708d20", "Admin", "ADMIN" },
                    { new Guid("dbb88edb-5fd7-425f-af37-4cbd734a8a2b"), "99d3e31f-c8de-4467-b8fa-d85e0edadb71", "User", "USER" },
                    { new Guid("f43ef6c8-3149-454c-b68f-e26ff24ccda1"), "1b0534cd-30ff-4272-9a66-34e71008ef28", "Guest", "GUEST" }
                });
        }
    }
}
