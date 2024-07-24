using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.EnsureSchema(
                name: "vehicles");

            migrationBuilder.EnsureSchema(
                name: "locations");

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "identity",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity",
                columns: table => new
                {
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBodyTypes",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HexValue = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDrivetrainTypes",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDrivetrainTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleEngineTypes",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEngineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLocationRegions",
                schema: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocationRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLocationTownTypes",
                schema: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocationTownTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransmissionTypes",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTransmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                schema: "identity",
                columns: table => new
                {
                    PermissionCode = table.Column<string>(type: "character varying(64)", nullable: false),
                    UserRoleName = table.Column<string>(type: "character varying(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionCode, x.UserRoleName });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionCode",
                        column: x => x.PermissionCode,
                        principalSchema: "identity",
                        principalTable: "Permissions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_UserRoles_UserRoleName",
                        column: x => x.UserRoleName,
                        principalSchema: "identity",
                        principalTable: "UserRoles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserRoleName = table.Column<string>(type: "character varying(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleName",
                        column: x => x.UserRoleName,
                        principalSchema: "identity",
                        principalTable: "UserRoles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLocationAreas",
                schema: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationRegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocationAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLocationAreas_VehicleLocationRegions_LocationRegionId",
                        column: x => x.LocationRegionId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MinimalProductionYear = table.Column<int>(type: "integer", nullable: false),
                    MaximumProductionYear = table.Column<int>(type: "integer", nullable: true),
                    VehicleBrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLocationTowns",
                schema: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationRegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationTownTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocationTowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLocationTowns_VehicleLocationAreas_LocationAreaId",
                        column: x => x.LocationAreaId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleLocationTowns_VehicleLocationRegions_LocationRegionId",
                        column: x => x.LocationRegionId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleLocationTowns_VehicleLocationTownTypes_LocationTownT~",
                        column: x => x.LocationTownTypeId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationTownTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBodyTypesVehicleModels",
                schema: "vehicles",
                columns: table => new
                {
                    AvailableBodyTypesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodyTypesVehicleModels", x => new { x.AvailableBodyTypesId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_VehicleBodyTypesVehicleModels_VehicleBodyTypes_AvailableBod~",
                        column: x => x.AvailableBodyTypesId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleBodyTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDrivetrainTypesVehicleModels",
                schema: "vehicles",
                columns: table => new
                {
                    AvailableDrivetrainTypesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDrivetrainTypesVehicleModels", x => new { x.AvailableDrivetrainTypesId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_VehicleDrivetrainTypesVehicleModels_VehicleDrivetrainTypes_~",
                        column: x => x.AvailableDrivetrainTypesId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleDrivetrainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleDrivetrainTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleEngineTypesVehicleModels",
                schema: "vehicles",
                columns: table => new
                {
                    AvailableEngineTypesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEngineTypesVehicleModels", x => new { x.AvailableEngineTypesId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_VehicleEngineTypesVehicleModels_VehicleEngineTypes_Availabl~",
                        column: x => x.AvailableEngineTypesId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleEngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleEngineTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransmissionTypesVehicleModels",
                schema: "vehicles",
                columns: table => new
                {
                    AvailableTransmissionTypesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTransmissionTypesVehicleModels", x => new { x.AvailableTransmissionTypesId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_VehicleTransmissionTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleTransmissionTypesVehicleModels_VehicleTransmissionTy~",
                        column: x => x.AvailableTransmissionTypesId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleTransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    Displacement = table.Column<double>(type: "double precision", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    LocationTownId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationRegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    BodyTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransmissionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    DrivetrainTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBrands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleColors_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleDrivetrainTypes_DrivetrainTypeId",
                        column: x => x.DrivetrainTypeId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleDrivetrainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleEngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleEngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleLocationAreas_LocationAreaId",
                        column: x => x.LocationAreaId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleLocationRegions_LocationRegionId",
                        column: x => x.LocationRegionId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleLocationTowns_LocationTownId",
                        column: x => x.LocationTownId,
                        principalSchema: "locations",
                        principalTable: "VehicleLocationTowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleTransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "vehicles",
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CloudImageId = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsMainImage = table.Column<bool>(type: "boolean", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleImages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "vehicles",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePrices",
                schema: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePrices_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "vehicles",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Permissions",
                column: "Code",
                values: new object[]
                {
                    "brands:create",
                    "brands:update",
                    "models:create",
                    "models:update",
                    "users:change-role",
                    "users:create",
                    "users:delete",
                    "users:list",
                    "users:read",
                    "users:update",
                    "vehicles:create",
                    "vehicles:delete",
                    "vehicles:update"
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "UserRoles",
                column: "Name",
                values: new object[]
                {
                    "Administrator",
                    "Manager",
                    "User"
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "RolePermissions",
                columns: new[] { "PermissionCode", "UserRoleName" },
                values: new object[,]
                {
                    { "brands:create", "Administrator" },
                    { "brands:create", "Manager" },
                    { "brands:update", "Administrator" },
                    { "brands:update", "Manager" },
                    { "models:create", "Administrator" },
                    { "models:create", "Manager" },
                    { "models:update", "Administrator" },
                    { "models:update", "Manager" },
                    { "users:change-role", "Administrator" },
                    { "users:create", "Administrator" },
                    { "users:create", "Manager" },
                    { "users:delete", "Administrator" },
                    { "users:delete", "Manager" },
                    { "users:list", "Administrator" },
                    { "users:list", "Manager" },
                    { "users:read", "Administrator" },
                    { "users:read", "Manager" },
                    { "users:read", "User" },
                    { "users:update", "Administrator" },
                    { "users:update", "Manager" },
                    { "vehicles:create", "Administrator" },
                    { "vehicles:create", "Manager" },
                    { "vehicles:create", "User" },
                    { "vehicles:update", "Administrator" },
                    { "vehicles:update", "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_UserRoleName",
                schema: "identity",
                table: "RolePermissions",
                column: "UserRoleName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleName",
                schema: "identity",
                table: "Users",
                column: "UserRoleName");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_Name",
                schema: "vehicles",
                table: "VehicleBodyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypesVehicleModels_ModelsId",
                schema: "vehicles",
                table: "VehicleBodyTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBrands_Name",
                schema: "vehicles",
                table: "VehicleBrands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleColors_Name",
                schema: "vehicles",
                table: "VehicleColors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDrivetrainTypes_Name",
                schema: "vehicles",
                table: "VehicleDrivetrainTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDrivetrainTypesVehicleModels_ModelsId",
                schema: "vehicles",
                table: "VehicleDrivetrainTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEngineTypes_Name",
                schema: "vehicles",
                table: "VehicleEngineTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEngineTypesVehicleModels_ModelsId",
                schema: "vehicles",
                table: "VehicleEngineTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleId",
                schema: "vehicles",
                table: "VehicleImages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationAreas_LocationRegionId",
                schema: "locations",
                table: "VehicleLocationAreas",
                column: "LocationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationAreas_Name",
                schema: "locations",
                table: "VehicleLocationAreas",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationRegions_Name",
                schema: "locations",
                table: "VehicleLocationRegions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationAreaId",
                schema: "locations",
                table: "VehicleLocationTowns",
                column: "LocationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationRegionId",
                schema: "locations",
                table: "VehicleLocationTowns",
                column: "LocationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationTownTypeId",
                schema: "locations",
                table: "VehicleLocationTowns",
                column: "LocationTownTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTownTypes_Name",
                schema: "locations",
                table: "VehicleLocationTownTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name_VehicleBrandId",
                schema: "vehicles",
                table: "VehicleModels",
                columns: new[] { "Name", "VehicleBrandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandId",
                schema: "vehicles",
                table: "VehicleModels",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleTypeId",
                schema: "vehicles",
                table: "VehicleModels",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePrices_VehicleId",
                schema: "vehicles",
                table: "VehiclePrices",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BodyTypeId",
                schema: "vehicles",
                table: "Vehicles",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandId",
                schema: "vehicles",
                table: "Vehicles",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                schema: "vehicles",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DrivetrainTypeId",
                schema: "vehicles",
                table: "Vehicles",
                column: "DrivetrainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineTypeId",
                schema: "vehicles",
                table: "Vehicles",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationAreaId",
                schema: "vehicles",
                table: "Vehicles",
                column: "LocationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationRegionId",
                schema: "vehicles",
                table: "Vehicles",
                column: "LocationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationTownId",
                schema: "vehicles",
                table: "Vehicles",
                column: "LocationTownId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                schema: "vehicles",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionTypeId",
                schema: "vehicles",
                table: "Vehicles",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                schema: "vehicles",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                schema: "vehicles",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransmissionTypes_Name",
                schema: "vehicles",
                table: "VehicleTransmissionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransmissionTypesVehicleModels_ModelsId",
                schema: "vehicles",
                table: "VehicleTransmissionTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Name",
                schema: "vehicles",
                table: "VehicleTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "VehicleBodyTypesVehicleModels",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleDrivetrainTypesVehicleModels",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleEngineTypesVehicleModels",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleImages",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehiclePrices",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTransmissionTypesVehicleModels",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "VehicleBodyTypes",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleColors",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleDrivetrainTypes",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleEngineTypes",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleLocationTowns",
                schema: "locations");

            migrationBuilder.DropTable(
                name: "VehicleModels",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTransmissionTypes",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "VehicleLocationAreas",
                schema: "locations");

            migrationBuilder.DropTable(
                name: "VehicleLocationTownTypes",
                schema: "locations");

            migrationBuilder.DropTable(
                name: "VehicleBrands",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "VehicleLocationRegions",
                schema: "locations");
        }
    }
}
