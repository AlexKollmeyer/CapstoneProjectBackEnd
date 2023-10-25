using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class purchasearchivemodelupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a354e25-f58e-4363-86fe-7f1390f6e442");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc89045-6652-4709-b3a0-c8aa97e62dc9");

            migrationBuilder.AddColumn<double>(
                name: "OriginalPrice",
                table: "PurchaseArchives",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Savings",
                table: "PurchaseArchives",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22f4a3bf-2031-4ce0-829c-1ad8a12dd005", null, "Admin", "ADMIN" },
                    { "c095fdf4-92cf-477c-8627-61e5f7787b05", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "OriginalPrice",
                table: "PurchaseArchives");

            migrationBuilder.DropColumn(
                name: "Savings",
                table: "PurchaseArchives");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a354e25-f58e-4363-86fe-7f1390f6e442", null, "User", "USER" },
                    { "2fc89045-6652-4709-b3a0-c8aa97e62dc9", null, "Admin", "ADMIN" }
                });
        }
    }
}
