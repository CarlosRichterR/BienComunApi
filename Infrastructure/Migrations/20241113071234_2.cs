using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BienComun.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "LastModifiedDate", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 10, 20, 0, 0, 0, DateTimeKind.Utc), "testuser@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password123", "TestUser" },
                    { 2, new DateTime(2024, 11, 10, 20, 15, 0, 0, DateTimeKind.Utc), "janedoe@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password456", "JaneDoe" },
                    { 3, new DateTime(2024, 11, 10, 20, 30, 0, 0, DateTimeKind.Utc), "johnsmith@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password789", "JohnSmith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
