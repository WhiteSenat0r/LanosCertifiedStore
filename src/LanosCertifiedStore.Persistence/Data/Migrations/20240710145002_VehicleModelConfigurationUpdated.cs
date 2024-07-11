using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleModelConfigurationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_Name",
                table: "VehicleModels");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name_VehicleBrandId",
                table: "VehicleModels",
                columns: new[] { "Name", "VehicleBrandId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_Name_VehicleBrandId",
                table: "VehicleModels");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name",
                table: "VehicleModels",
                column: "Name",
                unique: true);
        }
    }
}
