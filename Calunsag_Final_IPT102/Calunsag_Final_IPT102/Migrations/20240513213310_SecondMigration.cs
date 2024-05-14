using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Calunsag_Final_IPT102.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11b07edf-c9ce-4c07-9e71-195ad0b7abe6", null, "admin", "admin" },
                    { "536407ca-57f7-4c5d-aaf0-3da19d864968", null, "seller", "seller" },
                    { "cce0d741-6556-48d3-883f-26c1fb190518", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11b07edf-c9ce-4c07-9e71-195ad0b7abe6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "536407ca-57f7-4c5d-aaf0-3da19d864968");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cce0d741-6556-48d3-883f-26c1fb190518");
        }
    }
}
