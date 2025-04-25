using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddListDetailsToGiftList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "GiftLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CampaignEndDate",
                table: "GiftLists",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignEndTime",
                table: "GiftLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CampaignStartDate",
                table: "GiftLists",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignStartTime",
                table: "GiftLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "GiftLists",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListName",
                table: "GiftLists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double[]>(
                name: "Location",
                table: "GiftLists",
                type: "double precision[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "CampaignEndDate",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "CampaignEndTime",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "CampaignStartDate",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "CampaignStartTime",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "ListName",
                table: "GiftLists");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "GiftLists");
        }
    }
}
