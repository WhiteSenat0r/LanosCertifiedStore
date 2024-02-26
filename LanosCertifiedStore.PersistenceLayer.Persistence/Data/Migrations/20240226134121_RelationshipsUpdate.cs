using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a05f8474-fc3c-46c5-9fee-a38e52240346"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d12687d2-0d77-4ba1-983f-ee8847528469"));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevocationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelDataModelVehicleTypeDataModel",
                columns: table => new
                {
                    ModelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelDataModelVehicleTypeDataModel", x => new { x.ModelsId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_VehicleModelDataModelVehicleTypeDataModel_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelDataModelVehicleTypeDataModel_VehicleTypes_TypesId",
                        column: x => x.TypesId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2cd2af53-dca8-4dd2-9811-ee8fb4819472"), "User" },
                    { new Guid("d3a90b0b-a22c-4d0c-b75b-f4c2c8d59fca"), "Administrator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelDataModelVehicleTypeDataModel_TypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                column: "TypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2cd2af53-dca8-4dd2-9811-ee8fb4819472"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d3a90b0b-a22c-4d0c-b75b-f4c2c8d59fca"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a05f8474-fc3c-46c5-9fee-a38e52240346"), "Administrator" },
                    { new Guid("d12687d2-0d77-4ba1-983f-ee8847528469"), "User" }
                });
        }
    }
}
