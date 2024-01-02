using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class FixCricularReferencesReversed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2685f17e-83c2-4e31-9cb8-d0d24b24ce64"), "31c24d54-76d9-44f5-8b1b-10ab65f320e1", "Admin", "ADMIN" },
                    { new Guid("52a247c5-f0ef-4985-a7e1-3aaa0947885d"), "c356f705-234c-43bc-aa9e-e9288110a675", "User", "USER" },
                    { new Guid("aaafae60-c78f-4cc2-b415-42531f2bfcb7"), "3ef519e2-773a-4068-b83f-89770f1f7957", "Guest", "GUEST" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2685f17e-83c2-4e31-9cb8-d0d24b24ce64"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52a247c5-f0ef-4985-a7e1-3aaa0947885d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aaafae60-c78f-4cc2-b415-42531f2bfcb7"));

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
    }
}
