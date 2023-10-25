using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class modelsupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02826bcd-2b15-4c0a-8d85-281ade12b9b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59de2413-2986-49fa-a7ea-d2ee9bae8830");

            migrationBuilder.CreateTable(
                name: "PurchaseArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PurchasedGameTitle = table.Column<string>(type: "longtext", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PurchaseAmount = table.Column<double>(type: "double", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseArchives_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WishListedGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "longtext", nullable: true),
                    Thumbnail = table.Column<string>(type: "longtext", nullable: true),
                    CheapestCurrentDealId = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListedGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishListedGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a354e25-f58e-4363-86fe-7f1390f6e442", null, "User", "USER" },
                    { "2fc89045-6652-4709-b3a0-c8aa97e62dc9", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseArchives_UserId",
                table: "PurchaseArchives",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListedGames_UserId",
                table: "WishListedGames",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseArchives");

            migrationBuilder.DropTable(
                name: "WishListedGames");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a354e25-f58e-4363-86fe-7f1390f6e442");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc89045-6652-4709-b3a0-c8aa97e62dc9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02826bcd-2b15-4c0a-8d85-281ade12b9b9", null, "Admin", "ADMIN" },
                    { "59de2413-2986-49fa-a7ea-d2ee9bae8830", null, "User", "USER" }
                });
        }
    }
}
