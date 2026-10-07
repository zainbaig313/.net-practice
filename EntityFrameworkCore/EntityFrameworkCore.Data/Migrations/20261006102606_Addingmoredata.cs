using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingmoredata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "manchester city" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "manchester united" },
                    { 5, new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "liverpool" },
                    { 6, new DateTime(2026, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "arsenal" },
                    { 7, new DateTime(2026, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "chelsea" },
                    { 8, new DateTime(2026, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "tottenham" },
                    { 9, new DateTime(2026, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "bayern munich" },
                    { 10, new DateTime(2026, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "borussia dortmund" },
                    { 11, new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "inter milan" },
                    { 12, new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ac milan" },
                    { 13, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "juventus" },
                    { 14, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "napoli" },
                    { 15, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "psg" },
                    { 16, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "marseille" },
                    { 17, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "realmadrid" },
                    { 18, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "barcelona" },
                    { 19, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "liverpool" },
                    { 20, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "arsenal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                columns: new[] { "DateCreated", "Name" },
                values: new object[] { new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "city" });
        }
    }
}
