using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39812ae4-18ee-4687-90d9-0215fe4024da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b470f4ff-1cf4-49b0-8416-2e151a91883f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ad1bea4-6cb9-4f93-a00e-6da1ff5ee7a9", null, "User", "USER" },
                    { "8668dc8d-0195-4a64-b531-ccb6a4fdc4b8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad1bea4-6cb9-4f93-a00e-6da1ff5ee7a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8668dc8d-0195-4a64-b531-ccb6a4fdc4b8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39812ae4-18ee-4687-90d9-0215fe4024da", null, "User", "USER" },
                    { "b470f4ff-1cf4-49b0-8416-2e151a91883f", null, "Admin", "ADMIN" }
                });
        }
    }
}
