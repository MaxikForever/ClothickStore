using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Clothick.Infrastructure.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ProductRatings");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductRatingId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_ProductRatings_ProductRatingId",
                        column: x => x.ProductRatingId,
                        principalTable: "ProductRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4ce3060c-955c-4837-8c4e-6c612fe397e0"), "bc135502-2395-4ba8-bcd4-4c8a6fb1f21f", "User", "USER" },
                    { new Guid("be491b30-55cd-40c5-9096-0355c7d0a438"), "2d249b02-575a-48a2-9688-977a9b5ff34f", "Guest", "GUEST" },
                    { new Guid("d6df8670-962a-45f2-855e-ec27240bf3fc"), "b9134c3e-93a2-4587-aef4-a57f410aa3fe", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductRatingId",
                table: "Comment",
                column: "ProductRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

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

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ProductRatings",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
