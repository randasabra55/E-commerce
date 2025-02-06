using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class editColumTotalPriceInTableOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "order");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05b5549e-bf13-47d4-a82b-02f61aafa03b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a83a40f-9314-4db5-b2db-2674d6440635");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59d78c7d-e64a-4f7c-aa9e-c2f032637ac1", "34eb52fa-240a-4ec5-920d-af7d4158598d", "Customer", "customer" },
                    { "bb4fe729-93d1-4caa-a4e2-2f6e4a85a15a", "3fed0d3e-0e63-480b-ad2d-91e56b68cb91", "Admin", "admin" }
                });
        }
    }
}
