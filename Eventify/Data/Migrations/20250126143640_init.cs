using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5f3a6f15-892a-4dfe-ae6d-45c5a7f94249", null, null, "ADMIN", "USER" },
                    { "91e2e169-5373-43c0-9662-bc6d36b7e97d", null, null, "USER", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3a6f15-892a-4dfe-ae6d-45c5a7f94249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91e2e169-5373-43c0-9662-bc6d36b7e97d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b5622b0-449b-4996-863f-430bd1e5ef29", null, null, "USER", "USER" },
                    { "49fcf651-43f5-4fe8-907d-31a47a0aedbd", null, null, "ADMIN", "USER" }
                });
        }
    }
}
