using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class CommentStarRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bba074a-1a73-402d-b409-618438cf01dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7754815b-e1a4-4135-9910-c5175777a1b7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9aba156f-32be-43bf-8cd1-8509fad37962"));

            migrationBuilder.AddColumn<decimal>(
                name: "StarRating",
                table: "Comment",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("101ea5a1-bfd3-43b5-a18f-1da02c410f03"), "adc22a82-bb17-4273-869f-858e05ff8b7f", "Guest", "GUEST" },
                    { new Guid("2e3c96d7-53b1-46d4-9490-b53f97b48fd3"), "d8db6c6e-04bd-4cf8-903b-192683f085cd", "Admin", "ADMIN" },
                    { new Guid("8a264558-d221-4f2c-b4b4-b42144703f5a"), "1fa358dd-c8f2-494d-ab2e-1b829e0ff974", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("101ea5a1-bfd3-43b5-a18f-1da02c410f03"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e3c96d7-53b1-46d4-9490-b53f97b48fd3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8a264558-d221-4f2c-b4b4-b42144703f5a"));

            migrationBuilder.DropColumn(
                name: "StarRating",
                table: "Comment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0bba074a-1a73-402d-b409-618438cf01dc"), "2bfecf75-4ddd-4ce8-88a0-9a84bbc6c223", "Admin", "ADMIN" },
                    { new Guid("7754815b-e1a4-4135-9910-c5175777a1b7"), "6187ce11-e0bd-410c-9de2-3df31a23125f", "User", "USER" },
                    { new Guid("9aba156f-32be-43bf-8cd1-8509fad37962"), "f4522fb6-85e4-4607-8554-5554c8b9fabe", "Guest", "GUEST" }
                });
        }
    }
}
