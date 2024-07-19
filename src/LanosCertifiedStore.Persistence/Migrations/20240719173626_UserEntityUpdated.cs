using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehiclesBrands_VehicleBrandId",
                table: "VehicleModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehiclesBrands_BrandId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLocationTowns_Name",
                table: "VehicleLocationTowns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclesBrands",
                table: "VehiclesBrands");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.EnsureSchema(
                name: "vehicles");

            migrationBuilder.EnsureSchema(
                name: "locations");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                newName: "VehicleTypes",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleTransmissionTypesVehicleModels",
                newName: "VehicleTransmissionTypesVehicleModels",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleTransmissionTypes",
                newName: "VehicleTransmissionTypes",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicles",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehiclePrices",
                newName: "VehiclePrices",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleModels",
                newName: "VehicleModels",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleLocationTownTypes",
                newName: "VehicleLocationTownTypes",
                newSchema: "locations");

            migrationBuilder.RenameTable(
                name: "VehicleLocationTowns",
                newName: "VehicleLocationTowns",
                newSchema: "locations");

            migrationBuilder.RenameTable(
                name: "VehicleLocationRegions",
                newName: "VehicleLocationRegions",
                newSchema: "locations");

            migrationBuilder.RenameTable(
                name: "VehicleLocationAreas",
                newName: "VehicleLocationAreas",
                newSchema: "locations");

            migrationBuilder.RenameTable(
                name: "VehicleImages",
                newName: "VehicleImages",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleEngineTypesVehicleModels",
                newName: "VehicleEngineTypesVehicleModels",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleEngineTypes",
                newName: "VehicleEngineTypes",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleDrivetrainTypesVehicleModels",
                newName: "VehicleDrivetrainTypesVehicleModels",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleDrivetrainTypes",
                newName: "VehicleDrivetrainTypes",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleColors",
                newName: "VehicleColors",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleBodyTypesVehicleModels",
                newName: "VehicleBodyTypesVehicleModels",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleBodyTypes",
                newName: "VehicleBodyTypes",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "VehiclesBrands",
                newName: "VehicleBrands",
                newSchema: "vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclesBrands_Name",
                schema: "vehicles",
                table: "VehicleBrands",
                newName: "IX_VehicleBrands_Name");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "vehicles",
                table: "Vehicles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleBrands",
                schema: "vehicles",
                table: "VehicleBrands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdentityId = table.Column<string>(type: "text", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "identity",
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b11031d0-5f28-42b3-a799-9416aa0a52d4"), "Користувач" },
                    { new Guid("e18ff0c0-8be7-4d7d-8e9c-056a59f9e467"), "Менеджер" },
                    { new Guid("f2f99306-a798-43be-a8d3-4aa9d5656e1d"), "Адміністратор" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                schema: "vehicles",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Name",
                schema: "identity",
                table: "UserRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "identity",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentityId",
                schema: "identity",
                table: "Users",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                schema: "identity",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehicleBrands_VehicleBrandId",
                schema: "vehicles",
                table: "VehicleModels",
                column: "VehicleBrandId",
                principalSchema: "vehicles",
                principalTable: "VehicleBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_UserId",
                schema: "vehicles",
                table: "Vehicles",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleBrands_BrandId",
                schema: "vehicles",
                table: "Vehicles",
                column: "BrandId",
                principalSchema: "vehicles",
                principalTable: "VehicleBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_VehicleBrands_VehicleBrandId",
                schema: "vehicles",
                table: "VehicleModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_UserId",
                schema: "vehicles",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleBrands_BrandId",
                schema: "vehicles",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                schema: "vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleBrands",
                schema: "vehicles",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                schema: "vehicles",
                newName: "VehicleTypes");

            migrationBuilder.RenameTable(
                name: "VehicleTransmissionTypesVehicleModels",
                schema: "vehicles",
                newName: "VehicleTransmissionTypesVehicleModels");

            migrationBuilder.RenameTable(
                name: "VehicleTransmissionTypes",
                schema: "vehicles",
                newName: "VehicleTransmissionTypes");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                schema: "vehicles",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "VehiclePrices",
                schema: "vehicles",
                newName: "VehiclePrices");

            migrationBuilder.RenameTable(
                name: "VehicleModels",
                schema: "vehicles",
                newName: "VehicleModels");

            migrationBuilder.RenameTable(
                name: "VehicleLocationTownTypes",
                schema: "locations",
                newName: "VehicleLocationTownTypes");

            migrationBuilder.RenameTable(
                name: "VehicleLocationTowns",
                schema: "locations",
                newName: "VehicleLocationTowns");

            migrationBuilder.RenameTable(
                name: "VehicleLocationRegions",
                schema: "locations",
                newName: "VehicleLocationRegions");

            migrationBuilder.RenameTable(
                name: "VehicleLocationAreas",
                schema: "locations",
                newName: "VehicleLocationAreas");

            migrationBuilder.RenameTable(
                name: "VehicleImages",
                schema: "vehicles",
                newName: "VehicleImages");

            migrationBuilder.RenameTable(
                name: "VehicleEngineTypesVehicleModels",
                schema: "vehicles",
                newName: "VehicleEngineTypesVehicleModels");

            migrationBuilder.RenameTable(
                name: "VehicleEngineTypes",
                schema: "vehicles",
                newName: "VehicleEngineTypes");

            migrationBuilder.RenameTable(
                name: "VehicleDrivetrainTypesVehicleModels",
                schema: "vehicles",
                newName: "VehicleDrivetrainTypesVehicleModels");

            migrationBuilder.RenameTable(
                name: "VehicleDrivetrainTypes",
                schema: "vehicles",
                newName: "VehicleDrivetrainTypes");

            migrationBuilder.RenameTable(
                name: "VehicleColors",
                schema: "vehicles",
                newName: "VehicleColors");

            migrationBuilder.RenameTable(
                name: "VehicleBodyTypesVehicleModels",
                schema: "vehicles",
                newName: "VehicleBodyTypesVehicleModels");

            migrationBuilder.RenameTable(
                name: "VehicleBodyTypes",
                schema: "vehicles",
                newName: "VehicleBodyTypes");

            migrationBuilder.RenameTable(
                name: "VehicleBrands",
                schema: "vehicles",
                newName: "VehiclesBrands");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleBrands_Name",
                table: "VehiclesBrands",
                newName: "IX_VehiclesBrands_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclesBrands",
                table: "VehiclesBrands",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_Name",
                table: "VehicleLocationTowns",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_VehiclesBrands_VehicleBrandId",
                table: "VehicleModels",
                column: "VehicleBrandId",
                principalTable: "VehiclesBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehiclesBrands_BrandId",
                table: "Vehicles",
                column: "BrandId",
                principalTable: "VehiclesBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
