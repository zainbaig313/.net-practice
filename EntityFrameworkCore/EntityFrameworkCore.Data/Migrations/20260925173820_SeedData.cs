using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "realmadrid" },
                    { 2, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "barcelona" },
                    { 3, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "city" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);
        }
    }
}
