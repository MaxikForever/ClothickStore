using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class ProductImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    ProductVariantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("93778b5e-73bc-4c57-94e3-222a5b5eaa7e"), "83a36950-54f3-42cb-b4af-312cd6708d20", "Admin", "ADMIN" },
                    { new Guid("dbb88edb-5fd7-425f-af37-4cbd734a8a2b"), "99d3e31f-c8de-4467-b8fa-d85e0edadb71", "User", "USER" },
                    { new Guid("f43ef6c8-3149-454c-b68f-e26ff24ccda1"), "1b0534cd-30ff-4272-9a66-34e71008ef28", "Guest", "GUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductVariantId",
                table: "Images",
                column: "ProductVariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

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

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("101ea5a1-bfd3-43b5-a18f-1da02c410f03"), "adc22a82-bb17-4273-869f-858e05ff8b7f", "Guest", "GUEST" },
                    { new Guid("2e3c96d7-53b1-46d4-9490-b53f97b48fd3"), "d8db6c6e-04bd-4cf8-903b-192683f085cd", "Admin", "ADMIN" },
                    { new Guid("8a264558-d221-4f2c-b4b4-b42144703f5a"), "1fa358dd-c8f2-494d-ab2e-1b829e0ff974", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");
        }
    }
}
