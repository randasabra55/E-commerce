using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22e3bedb-6ebf-493c-86bc-5420ac323c9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8c22831-c429-4c52-a76e-c8c91b0b3ba6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43622747-1a7c-4e89-befc-3f2f2785f09b", "49dc33a2-867d-40b7-99a0-8fff77ea088c", "Customer", "customer" },
                    { "7a07a7a8-5daa-4b4b-8f62-c3e5017b480a", "2ef8c2ea-9e41-4bfe-b23f-07e9c105f68c", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43622747-1a7c-4e89-befc-3f2f2785f09b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a07a7a8-5daa-4b4b-8f62-c3e5017b480a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22e3bedb-6ebf-493c-86bc-5420ac323c9f", "3d78bded-0f9d-48d9-8735-4351b4a5b9a2", "Customer", "customer" },
                    { "c8c22831-c429-4c52-a76e-c8c91b0b3ba6", "e0301595-4681-4ca8-8693-a456b1c639ea", "Admin", "admin" }
                });
        }
    }
}
