using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalHealthTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHealthTrackingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HealthRecords");

            migrationBuilder.AddColumn<int>(
                name: "FlossingCount",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MouthwashUsage",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToothBrushingCount",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlossingCount",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "MouthwashUsage",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "ToothBrushingCount",
                table: "HealthRecords");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HealthRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
