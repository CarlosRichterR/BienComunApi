using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productsup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceUrl",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 10, "https://www.lg.com/mx/refrigeradores" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 15, "https://www.liverpool.com.mx/tienda/pdp/velador-de-madera/" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 8, "https://www.samsung.com/mx/tvs/" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 12, "https://www.lg.com/mx/lavadoras" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 20, "https://www.liverpool.com.mx/tienda/pdp/juego-de-vajillas/" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 5, "https://www.homedepot.com.mx/herramientas/soldadoras" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGlvJg8PYiywWaCNkmV6xo_Rh7YYtyGgLlyA&s", 14, "https://www.lg.com/mx/microondas" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 18, "https://www.oster.com.mx/cafeteras/" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnHriuHz4o1LjWMi-lGaiTD5GXhZCjTw1ITg&s", 7, "https://www.liverpool.com.mx/tienda/pdp/sofa/" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Quantity", "ReferenceUrl" },
                values: new object[] { "https://nextlevel.com.bo/cdn/shop/products/Lavadora-Samsung-WD12T754DBN-Merkamax-img-5_1024x1024@2x.png?v=1718831587", 6, "https://www.liverpool.com.mx/tienda/pdp/cama-queen-size/" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReferenceUrl",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 11, 2, "Espejo decorativo de 1.5 metros", "Espejo de Pared", 250m, 1 },
                    { 12, 1, "Licuadora de alta velocidad", "Licuadora", 480m, 2 },
                    { 13, 1, "Juego de ollas de acero inoxidable", "Juego de Ollas", 750m, 1 },
                    { 14, 1, "Aspiradora robótica inteligente", "Aspiradora", 800m, 2 },
                    { 15, 2, "Silla de madera con cojín", "Silla de Comedor", 150m, 1 },
                    { 16, 2, "Mesa de centro de vidrio y acero", "Mesa de Centro", 400m, 2 },
                    { 17, 3, "Taladro inalámbrico de 20V", "Taladro Eléctrico", 350m, 1 },
                    { 18, 3, "Barbacoa de gas con quemadores múltiples", "Barbacoa", 1500m, 2 },
                    { 19, 3, "Banco de trabajo con almacenamiento", "Banco de Trabajo", 600m, 1 },
                    { 20, 3, "Cortacésped eléctrico compacto", "Cortacésped", 900m, 2 }
                });
        }
    }
}
