using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalHealthTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedHealthSuggestionsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9917));
        }
    }
}
