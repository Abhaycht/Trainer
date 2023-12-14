using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trainer.Migrations
{
    /// <inheritdoc />
    public partial class seedTamersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tamers",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "India", "Marcus" },
                    { 2, "England", "Thomas" },
                    { 3, "Scotland", "Lily" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tamers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tamers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tamers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
