using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypesColumnRenamedInModelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModelDataModelVehicleTypeDataModel_VehicleTypes_TypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleModelDataModelVehicleTypeDataModel",
                table: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModelDataModelVehicleTypeDataModel_TypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2cd2af53-dca8-4dd2-9811-ee8fb4819472"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d3a90b0b-a22c-4d0c-b75b-f4c2c8d59fca"));

            migrationBuilder.RenameColumn(
                name: "TypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                newName: "AvailableTypesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleModelDataModelVehicleTypeDataModel",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                columns: new[] { "AvailableTypesId", "ModelsId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c698b903-7188-49d8-b88e-a631f194ce1b"), "Administrator" },
                    { new Guid("de7718f7-c4d3-4e56-8da5-2b72d0b9bb10"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelDataModelVehicleTypeDataModel_ModelsId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                column: "ModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModelDataModelVehicleTypeDataModel_VehicleTypes_AvailableTypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                column: "AvailableTypesId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModelDataModelVehicleTypeDataModel_VehicleTypes_AvailableTypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleModelDataModelVehicleTypeDataModel",
                table: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModelDataModelVehicleTypeDataModel_ModelsId",
                table: "VehicleModelDataModelVehicleTypeDataModel");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c698b903-7188-49d8-b88e-a631f194ce1b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("de7718f7-c4d3-4e56-8da5-2b72d0b9bb10"));

            migrationBuilder.RenameColumn(
                name: "AvailableTypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                newName: "TypesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleModelDataModelVehicleTypeDataModel",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                columns: new[] { "ModelsId", "TypesId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2cd2af53-dca8-4dd2-9811-ee8fb4819472"), "User" },
                    { new Guid("d3a90b0b-a22c-4d0c-b75b-f4c2c8d59fca"), "Administrator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelDataModelVehicleTypeDataModel_TypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModelDataModelVehicleTypeDataModel_VehicleTypes_TypesId",
                table: "VehicleModelDataModelVehicleTypeDataModel",
                column: "TypesId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
