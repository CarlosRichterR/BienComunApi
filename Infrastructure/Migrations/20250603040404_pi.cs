using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "ImageUrl", "IsThumbnail", "ProductId" },
                values: new object[,]
                {
                    { 1, "http://localhost:5088/assets/images/refrigerador1.png", false, 1 },
                    { 2, "http://localhost:5088/assets/images/refrigerador2.png", false, 1 },
                    { 3, "http://localhost:5088/assets/images/velador1.jpg", false, 2 },
                    { 4, "http://localhost:5088/assets/images/velador2.jpg", false, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
