using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsAndDrivers.Migrations
{
    public partial class inittest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Drivers",
                newName: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Drivers",
                newName: "OwnerId");
        }
    }
}
