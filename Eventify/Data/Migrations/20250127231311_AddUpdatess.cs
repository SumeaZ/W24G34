using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8df9322-c04f-4b32-9973-93d61319b27e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c58c5a76-4130-4cfe-99fd-41c2f7af526c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14becd8c-c6bf-4f19-a544-1bedee9994db", null, null, "USER", "USER" },
                    { "9f34f463-ee45-4194-bd9e-0173f8863316", null, null, "ADMIN", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "b8df9322-c04f-4b32-9973-93d61319b27e", null, null, "ADMIN", "USER" },
                    { "c58c5a76-4130-4cfe-99fd-41c2f7af526c", null, null, "USER", "USER" }
                });


        }
    }
}
