using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/CarlosRichterOpcion1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/velador.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/televisor.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/lavadora.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/vajillas.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/soldadora.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/microondas.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/cafetera.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/sofa.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ThumbnailUrl",
                value: "http://localhost:5088/assets/thumbnails/cama.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/CarlosRichterOpcion1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/velador.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/televisor.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/lavadora.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/vajillas.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/soldadora.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/microondas.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/cafetera.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/sofa.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ThumbnailUrl",
                value: "http://localhost:5000/assets/thumbnails/cama.jpg");
        }
    }
}
