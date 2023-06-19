using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelCountry_Redo.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestrictRefrentialAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c068f347-e9db-46b4-a2f4-9d37897ffe09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbec248-9fce-43ce-9e50-d1e5181791a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "939174e4-337d-4e85-97de-25450fe5c50a", null, "Administrator", "ADMINISTRATOR" },
                    { "e2463873-a0ed-4bbe-9b8d-f63dfd1e593f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "939174e4-337d-4e85-97de-25450fe5c50a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2463873-a0ed-4bbe-9b8d-f63dfd1e593f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c068f347-e9db-46b4-a2f4-9d37897ffe09", null, "Administrator", "ADMINISTRATOR" },
                    { "edbec248-9fce-43ce-9e50-d1e5181791a9", null, "User", "USER" }
                });
        }
    }
}
