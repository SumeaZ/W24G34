using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistrationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fea3dfd-7b52-4a3f-9d48-3622da71aff7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7f740b-3912-4991-a262-8345188d51ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b71a0e8-ffa6-4d57-99df-b7042b1f48cc", null, "USER", "USER" },
                    { "f2924c55-9935-42d5-9423-482bb732c153", null, "ADMIN", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fea3dfd-7b52-4a3f-9d48-3622da71aff7", null, "ADMIN", "USER" },
                    { "fe7f740b-3912-4991-a262-8345188d51ec", null, "USER", "USER" }
                });
        }
    }
}
