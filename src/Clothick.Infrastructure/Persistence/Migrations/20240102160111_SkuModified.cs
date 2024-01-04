using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class SkuModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ce3060c-955c-4837-8c4e-6c612fe397e0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be491b30-55cd-40c5-9096-0355c7d0a438"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6df8670-962a-45f2-855e-ec27240bf3fc"));

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "ProductVariants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5cd8806c-5cbc-4d9c-bccd-5f03effe0cef"), "cb72fe26-1624-4915-8bb1-2daad9220074", "Admin", "ADMIN" },
                    { new Guid("640085b8-aadd-44ac-b4f7-e957b1d9f412"), "e0982fde-a19f-41d0-a157-c0ada2682c7b", "User", "USER" },
                    { new Guid("754c1c6e-8e3a-4190-a954-2511841c8fab"), "6b9ba197-a143-45c6-a603-48b37be631b1", "Guest", "GUEST" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cd8806c-5cbc-4d9c-bccd-5f03effe0cef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("640085b8-aadd-44ac-b4f7-e957b1d9f412"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("754c1c6e-8e3a-4190-a954-2511841c8fab"));

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "ProductVariants");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4ce3060c-955c-4837-8c4e-6c612fe397e0"), "bc135502-2395-4ba8-bcd4-4c8a6fb1f21f", "User", "USER" },
                    { new Guid("be491b30-55cd-40c5-9096-0355c7d0a438"), "2d249b02-575a-48a2-9688-977a9b5ff34f", "Guest", "GUEST" },
                    { new Guid("d6df8670-962a-45f2-855e-ec27240bf3fc"), "b9134c3e-93a2-4587-aef4-a57f410aa3fe", "Admin", "ADMIN" }
                });
        }
    }
}
