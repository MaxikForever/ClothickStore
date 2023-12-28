using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class RolesSeedDataNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18881182-cc38-4d19-aa0e-9f2b18327927"), "b8537807-e1a3-4e12-8016-13360edd9b4d", "User", "USER" },
                    { new Guid("21bf22da-e47f-419f-b4b3-37ccf4953a9e"), "47764919-95f5-4555-88b7-6f8fa52c9d3b", "Admin", "ADMIN" },
                    { new Guid("6e98ca2a-6bb5-4fc8-aba3-50bf497c938c"), "173c96c3-6fb3-4c59-ac94-8efafd20a132", "Guest", "GUEST" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18881182-cc38-4d19-aa0e-9f2b18327927"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21bf22da-e47f-419f-b4b3-37ccf4953a9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e98ca2a-6bb5-4fc8-aba3-50bf497c938c"));
        }
    }
}
