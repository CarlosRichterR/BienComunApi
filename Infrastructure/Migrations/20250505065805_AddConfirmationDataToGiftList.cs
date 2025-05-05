using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfirmationDataToGiftList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GiftLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "GiftLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TermsAccepted",
                table: "GiftLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseMinContribution",
                table: "GiftLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "TermsAccepted",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "UseMinContribution",
                table: "GiftLists");
        }
    }
}
