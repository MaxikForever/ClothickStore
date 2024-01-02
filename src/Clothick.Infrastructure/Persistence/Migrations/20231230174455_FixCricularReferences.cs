using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class FixCricularReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("54834380-f271-42c0-bb94-dc23f3cc2656"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fa994c3-df4e-4bf7-ad35-1f1748ce097d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("848bc395-06aa-48e5-9761-b89cde569757"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("60620008-ed94-4463-b8af-f31408067e10"), "4c2f27e9-5a75-4c0d-91fc-51cd21294056", "Guest", "GUEST" },
                    { new Guid("ac9ff002-376a-42fd-977a-52f147ca41d4"), "84165e16-c4d7-4b09-a4bb-55d1eee8fb46", "User", "USER" },
                    { new Guid("dcd02c48-bcc3-40f5-96b0-220303176298"), "090b0684-e70b-4002-ab50-6f95c8ab907b", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60620008-ed94-4463-b8af-f31408067e10"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ac9ff002-376a-42fd-977a-52f147ca41d4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dcd02c48-bcc3-40f5-96b0-220303176298"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("54834380-f271-42c0-bb94-dc23f3cc2656"), "beb645f3-2612-457f-8b3f-c9adec46372f", "Guest", "GUEST" },
                    { new Guid("6fa994c3-df4e-4bf7-ad35-1f1748ce097d"), "0170b6e7-a7f4-4a87-a9cf-88394694238f", "Admin", "ADMIN" },
                    { new Guid("848bc395-06aa-48e5-9761-b89cde569757"), "b474bec1-2093-487c-89d4-8002aa6d3d46", "User", "USER" }
                });
        }
    }
}
