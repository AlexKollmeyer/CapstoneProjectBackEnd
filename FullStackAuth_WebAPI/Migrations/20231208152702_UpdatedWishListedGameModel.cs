using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedWishListedGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22f4a3bf-2031-4ce0-829c-1ad8a12dd005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c095fdf4-92cf-477c-8627-61e5f7787b05");

            migrationBuilder.DropColumn(
                name: "CheapestCurrentDealId",
                table: "WishListedGames");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67cd33ea-151e-46b4-89eb-1570601287c7", null, "Admin", "ADMIN" },
                    { "b4fb96e7-951c-461d-87a4-e58abc257b56", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67cd33ea-151e-46b4-89eb-1570601287c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4fb96e7-951c-461d-87a4-e58abc257b56");

            migrationBuilder.AddColumn<string>(
                name: "CheapestCurrentDealId",
                table: "WishListedGames",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22f4a3bf-2031-4ce0-829c-1ad8a12dd005", null, "Admin", "ADMIN" },
                    { "c095fdf4-92cf-477c-8627-61e5f7787b05", null, "User", "USER" }
                });
        }
    }
}
