using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanosCertifiedStore.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrimaryKey_InVehicleImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleImages",
                schema: "vehicles",
                table: "VehicleImages");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "vehicles",
                table: "VehicleImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleImages",
                schema: "vehicles",
                table: "VehicleImages",
                column: "CloudImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleImages",
                schema: "vehicles",
                table: "VehicleImages");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "vehicles",
                table: "VehicleImages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleImages",
                schema: "vehicles",
                table: "VehicleImages",
                column: "Id");
        }
    }
}
