using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thumbnail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ThumbnailUrl");

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsThumbnail = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGlvJg8PYiywWaCNkmV6xo_Rh7YYtyGgLlyA&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnHriuHz4o1LjWMi-lGaiTD5GXhZCjTw1ITg&s");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                column: "ProductId");
        }
    }
}
