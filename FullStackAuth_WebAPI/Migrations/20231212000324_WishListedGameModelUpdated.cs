using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class WishListedGameModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67cd33ea-151e-46b4-89eb-1570601287c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4fb96e7-951c-461d-87a4-e58abc257b56");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a353fcd1-0983-4191-a95b-6364a54ee6bd", null, "Admin", "ADMIN" },
                    { "e1883383-51f9-45a8-86ba-85ec80627c0d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a353fcd1-0983-4191-a95b-6364a54ee6bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1883383-51f9-45a8-86ba-85ec80627c0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67cd33ea-151e-46b4-89eb-1570601287c7", null, "Admin", "ADMIN" },
                    { "b4fb96e7-951c-461d-87a4-e58abc257b56", null, "User", "USER" }
                });
        }
    }
}
