using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class editQuantityType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "cartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e13ca17-06c6-472a-822e-58ce07346897");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76d3df09-9271-4ee8-8c6b-03416caab317");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "cartItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f674194-2adc-40e8-826f-a3b1b84f38fe", "c3d398c2-c311-43cd-9238-93c9b0343e25", "Customer", "customer" },
                    { "a052ec8a-8aa2-422a-a1f2-61e3a666764b", "02a19472-4f01-436d-8ade-e9592dd6d4fd", "Admin", "admin" }
                });
        }
    }
}
