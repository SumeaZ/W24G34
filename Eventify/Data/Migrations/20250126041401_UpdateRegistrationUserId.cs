using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventify.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistrationUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85aad905-b133-4aef-8d15-0fa9c129cbcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee0dbe6c-8051-4b35-af33-d76a9530d48d");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registrations",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fea3dfd-7b52-4a3f-9d48-3622da71aff7", null, null, "ADMIN", "USER" },
                    { "fe7f740b-3912-4991-a262-8345188d51ec", null, null, "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AspNetUsers_UserId",
                table: "Registrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AspNetUsers_UserId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fea3dfd-7b52-4a3f-9d48-3622da71aff7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7f740b-3912-4991-a262-8345188d51ec");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85aad905-b133-4aef-8d15-0fa9c129cbcd", null, null, "USER", "USER" },
                    { "ee0dbe6c-8051-4b35-af33-d76a9530d48d", null, null, "ADMIN", "USER" }
                });
        }
    }
}
