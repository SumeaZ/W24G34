using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14becd8c-c6bf-4f19-a544-1bedee9994db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f34f463-ee45-4194-bd9e-0173f8863316");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c31c5cc-c0a4-49a3-958d-5af5bae6f849", null, null, "USER", "USER" },
                    { "7300e5f8-6bb3-49c3-ae1d-91565f476551", null, null, "ADMIN", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c31c5cc-c0a4-49a3-958d-5af5bae6f849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7300e5f8-6bb3-49c3-ae1d-91565f476551");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14becd8c-c6bf-4f19-a544-1bedee9994db", null, null, "USER", "USER" },
                    { "9f34f463-ee45-4194-bd9e-0173f8863316", null, null, "ADMIN", "USER" }
                });
        }
    }
}
