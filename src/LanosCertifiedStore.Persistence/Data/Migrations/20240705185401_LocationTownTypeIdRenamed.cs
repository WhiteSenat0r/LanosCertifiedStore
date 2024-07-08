using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class LocationTownTypeIdRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLocationTowns_VehicleLocationTownTypes_LocationLocat~",
                table: "VehicleLocationTowns");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationTowns_LocationLocationTownTypeId",
                table: "VehicleLocationTowns");

            migrationBuilder.DropColumn(
                name: "LocationLocationTownTypeId",
                table: "VehicleLocationTowns");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationTownTypeId",
                table: "VehicleLocationTowns",
                column: "LocationTownTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLocationTowns_VehicleLocationTownTypes_LocationTownT~",
                table: "VehicleLocationTowns",
                column: "LocationTownTypeId",
                principalTable: "VehicleLocationTownTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLocationTowns_VehicleLocationTownTypes_LocationTownT~",
                table: "VehicleLocationTowns");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationTowns_LocationTownTypeId",
                table: "VehicleLocationTowns");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationLocationTownTypeId",
                table: "VehicleLocationTowns",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationLocationTownTypeId",
                table: "VehicleLocationTowns",
                column: "LocationLocationTownTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLocationTowns_VehicleLocationTownTypes_LocationLocat~",
                table: "VehicleLocationTowns",
                column: "LocationLocationTownTypeId",
                principalTable: "VehicleLocationTownTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
