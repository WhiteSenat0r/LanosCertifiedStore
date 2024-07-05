using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIndexesRemovedFromLocationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationRegions_Name",
                table: "VehicleLocationRegions");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationAreas_Name",
                table: "VehicleLocationAreas");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationRegions_Name",
                table: "VehicleLocationRegions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationAreas_Name",
                table: "VehicleLocationAreas",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationRegions_Name",
                table: "VehicleLocationRegions");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationAreas_Name",
                table: "VehicleLocationAreas");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationRegions_Name",
                table: "VehicleLocationRegions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationAreas_Name",
                table: "VehicleLocationAreas",
                column: "Name",
                unique: true);
        }
    }
}
