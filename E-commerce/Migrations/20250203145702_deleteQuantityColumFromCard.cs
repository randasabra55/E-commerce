using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class deleteQuantityColumFromCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "card");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59d78c7d-e64a-4f7c-aa9e-c2f032637ac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb4fe729-93d1-4caa-a4e2-2f6e4a85a15a");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e13ca17-06c6-472a-822e-58ce07346897", "a5a9ed18-0c08-44d2-8837-5d20d12de3fd", "Customer", "customer" },
                    { "76d3df09-9271-4ee8-8c6b-03416caab317", "73c37a92-06c8-4bcd-a59f-0a5fc8fe3a87", "Admin", "admin" }
                });
        }
    }
}
