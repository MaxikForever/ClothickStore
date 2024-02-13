using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class OrdersTablesStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab3256ab-03f4-469d-b2cb-6fca0c27d2d6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bc6dfde7-dfc0-465d-81f5-9d3e35339205"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c4c31d17-9978-41d1-af58-2d7cabdd259c"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2e4c2994-049e-48ea-a2ea-1f9bf56e5ff5"), "41eec440-88a1-4dd0-b971-86f2ff7db378", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c1137847-d235-4d81-93e6-adce03356cae"), "8a2b6e74-d9b8-406f-ad30-6907de224d2c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f6e3df4b-d50f-4149-be56-81a1f8c9aa13"), "a5f4ccc6-13cc-45fe-a543-96ea148c8c97", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e4c2994-049e-48ea-a2ea-1f9bf56e5ff5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1137847-d235-4d81-93e6-adce03356cae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6e3df4b-d50f-4149-be56-81a1f8c9aa13"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ab3256ab-03f4-469d-b2cb-6fca0c27d2d6"), "183d6c3f-d0de-4bb5-8dd6-335ddea37ba5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bc6dfde7-dfc0-465d-81f5-9d3e35339205"), "6a53041e-d7a1-4305-a636-07b171010a94", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c4c31d17-9978-41d1-af58-2d7cabdd259c"), "34c12e5f-7eb9-4074-8581-6599976a32f6", "Admin", "ADMIN" });
        }
    }
}
