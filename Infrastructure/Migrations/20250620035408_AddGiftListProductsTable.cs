using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGiftListProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_GiftListProduct_GiftListProductId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftListProduct_GiftLists_GiftListId",
                table: "GiftListProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftListProduct_Products_ProductId",
                table: "GiftListProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftListProduct",
                table: "GiftListProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribution",
                table: "Contribution");

            migrationBuilder.RenameTable(
                name: "GiftListProduct",
                newName: "GiftListProducts");

            migrationBuilder.RenameTable(
                name: "Contribution",
                newName: "Contributions");

            migrationBuilder.RenameIndex(
                name: "IX_GiftListProduct_ProductId",
                table: "GiftListProducts",
                newName: "IX_GiftListProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_GiftListProduct_GiftListId",
                table: "GiftListProducts",
                newName: "IX_GiftListProducts_GiftListId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_GiftListProductId",
                table: "Contributions",
                newName: "IX_Contributions_GiftListProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftListProducts",
                table: "GiftListProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contributions",
                table: "Contributions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_GiftListProducts_GiftListProductId",
                table: "Contributions",
                column: "GiftListProductId",
                principalTable: "GiftListProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiftListProducts_GiftLists_GiftListId",
                table: "GiftListProducts",
                column: "GiftListId",
                principalTable: "GiftLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiftListProducts_Products_ProductId",
                table: "GiftListProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_GiftListProducts_GiftListProductId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftListProducts_GiftLists_GiftListId",
                table: "GiftListProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GiftListProducts_Products_ProductId",
                table: "GiftListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftListProducts",
                table: "GiftListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contributions",
                table: "Contributions");

            migrationBuilder.RenameTable(
                name: "GiftListProducts",
                newName: "GiftListProduct");

            migrationBuilder.RenameTable(
                name: "Contributions",
                newName: "Contribution");

            migrationBuilder.RenameIndex(
                name: "IX_GiftListProducts_ProductId",
                table: "GiftListProduct",
                newName: "IX_GiftListProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_GiftListProducts_GiftListId",
                table: "GiftListProduct",
                newName: "IX_GiftListProduct_GiftListId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_GiftListProductId",
                table: "Contribution",
                newName: "IX_Contribution_GiftListProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftListProduct",
                table: "GiftListProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribution",
                table: "Contribution",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_GiftListProduct_GiftListProductId",
                table: "Contribution",
                column: "GiftListProductId",
                principalTable: "GiftListProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiftListProduct_GiftLists_GiftListId",
                table: "GiftListProduct",
                column: "GiftListId",
                principalTable: "GiftLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiftListProduct_Products_ProductId",
                table: "GiftListProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
