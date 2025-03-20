using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DentalHealthTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedHealthSuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "HealthSuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "IsActive" },
                values: new object[,]
                {
                    { 1, "Dişlerinizi günde en az 2 kez fırçalayın.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9319), true },
                    { 2, "Şekerli yiyeceklerden kaçının.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9911), true },
                    { 3, "Diş ipi kullanmayı ihmal etmeyin.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9912), true },
                    { 4, "Diş hekiminize düzenli olarak görünün.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9913), true },
                    { 5, "Sigara ve alkol tüketimini azaltın.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9914), true },
                    { 6, "Ağız çalkalama suyu kullanın.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9914), true },
                    { 7, "Sağlıklı beslenme diş sağlığınızı korur.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9915), true },
                    { 8, "Aşırı sert diş fırçalamaktan kaçının.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9916), true },
                    { 9, "Dişlerinizi yatmadan önce mutlaka fırçalayın.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9916), true },
                    { 10, "Asitli içecekleri sınırlayın.", new DateTime(2025, 3, 20, 12, 24, 20, 900, DateTimeKind.Utc).AddTicks(9917), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HealthSuggestions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
