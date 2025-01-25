using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReAddRoleIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4557a566-c7a7-47f2-902e-94c800128583", null, "This is the default user role", "USER", "USER" },
                    { "67aca24a-029f-451e-b43c-6dfd883fe1d5", null, "This is the administrator role", "ADMIN", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4557a566-c7a7-47f2-902e-94c800128583");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67aca24a-029f-451e-b43c-6dfd883fe1d5");
        }
    }
}
