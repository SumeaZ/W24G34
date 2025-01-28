using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af7161e-3c1a-48fd-a4e9-29fe50900fcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca30e50a-ad61-4f86-97d0-8a6f3ea97c11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29792465-0b18-453e-9318-0c9849145bb5", null, null, "USER", "USER" },
                    { "34919457-a46c-4b2f-b233-4874eb8dd1dd", null, null, "ADMIN", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29792465-0b18-453e-9318-0c9849145bb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34919457-a46c-4b2f-b233-4874eb8dd1dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6af7161e-3c1a-48fd-a4e9-29fe50900fcf", null, null, "ADMIN", "USER" },
                    { "ca30e50a-ad61-4f86-97d0-8a6f3ea97c11", null, null, "USER", "USER" }
                });
        }
    }
}
