using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class nameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "SizeName",
                table: "Sizes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ColorName",
                table: "Colors",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2393755b-ed67-47c4-88c6-f21bdde2ee04"), "532fe33c-169b-4c1b-babb-6afd22a1385c", "User", "USER" },
                    { new Guid("a403cc96-4649-42e8-a07d-16a29c7a9c6e"), "b456723f-4821-4a73-b8e5-5df929ba1610", "Guest", "GUEST" },
                    { new Guid("ae4b8944-8c6b-46aa-9293-b1a68d538e00"), "e5778620-7811-48ad-a50d-955db2527edb", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2393755b-ed67-47c4-88c6-f21bdde2ee04"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a403cc96-4649-42e8-a07d-16a29c7a9c6e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae4b8944-8c6b-46aa-9293-b1a68d538e00"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sizes",
                newName: "SizeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Colors",
                newName: "ColorName");

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
    }
}
