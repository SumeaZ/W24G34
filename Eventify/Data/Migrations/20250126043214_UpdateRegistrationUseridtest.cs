using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistrationUseridtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b71a0e8-ffa6-4d57-99df-b7042b1f48cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2924c55-9935-42d5-9423-482bb732c153");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b5622b0-449b-4996-863f-430bd1e5ef29", null, null, "USER", "USER" },
                    { "49fcf651-43f5-4fe8-907d-31a47a0aedbd", null, null, "ADMIN", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5622b0-449b-4996-863f-430bd1e5ef29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49fcf651-43f5-4fe8-907d-31a47a0aedbd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b71a0e8-ffa6-4d57-99df-b7042b1f48cc", null, null, "USER", "USER" },
                    { "f2924c55-9935-42d5-9423-482bb732c153", null, null, "ADMIN", "USER" }
                });
        }
    }
}
