using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleDisplacements_DisplacementId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleDisplacements");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_DisplacementId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DisplacementId",
                table: "Vehicles");

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloudImageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMainImage = table.Column<bool>(type: "bit", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleImages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleId",
                table: "VehicleImages",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.AddColumn<Guid>(
                name: "DisplacementId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VehicleDisplacements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(6,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDisplacements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DisplacementId",
                table: "Vehicles",
                column: "DisplacementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleDisplacements_DisplacementId",
                table: "Vehicles",
                column: "DisplacementId",
                principalTable: "VehicleDisplacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
