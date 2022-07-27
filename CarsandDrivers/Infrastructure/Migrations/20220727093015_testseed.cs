using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsAndDrivers.Migrations
{
    public partial class testseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "Volvo" },
                    { 4, "Fiat" },
                    { 3, "Volvo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "BrandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "BrandId",
                keyValue: 4);
        }
    }
}
