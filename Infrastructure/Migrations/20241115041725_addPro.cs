using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 7, 1, "Horno microondas compacto", "Microondas", 400m, 1 },
                    { 8, 1, "Cafetera eléctrica de acero inoxidable", "Cafetera", 120m, 2 },
                    { 9, 2, "Sofá de 3 plazas con tapizado de lino", "Sofá", 1000m, 1 },
                    { 10, 2, "Cama de madera con cabecera acolchada", "Cama Queen Size", 1200m, 2 },
                    { 11, 2, "Espejo decorativo de 1.5 metros", "Espejo de Pared", 250m, 1 },
                    { 12, 1, "Licuadora de alta velocidad", "Licuadora", 180m, 2 },
                    { 13, 1, "Juego de ollas de acero inoxidable", "Juego de Ollas", 350m, 1 },
                    { 14, 1, "Aspiradora robótica inteligente", "Aspiradora", 800m, 2 },
                    { 15, 2, "Silla de madera con cojín", "Silla de Comedor", 150m, 1 },
                    { 16, 2, "Mesa de centro de vidrio y acero", "Mesa de Centro", 400m, 2 },
                    { 17, 3, "Taladro inalámbrico de 20V", "Taladro Eléctrico", 350m, 1 },
                    { 18, 3, "Barbacoa de gas con quemadores múltiples", "Barbacoa", 1500m, 2 },
                    { 19, 3, "Banco de trabajo con almacenamiento", "Banco de Trabajo", 600m, 1 },
                    { 20, 3, "Cortacésped eléctrico compacto", "Cortacésped", 900m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

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
        }
    }
}
