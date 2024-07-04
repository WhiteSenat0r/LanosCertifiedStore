using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleBodyTypes",
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
                name: "VehicleDrivetrainTypes",
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
                name: "VehiclesBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HexValue = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransmissionTypes",
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
                name: "VehicleLocationAreas",
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
                        principalTable: "VehicleLocationRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
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
                        name: "FK_VehicleModels_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehiclesBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehiclesBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLocationTowns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationRegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLocationTowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLocationTowns_VehicleLocationAreas_LocationAreaId",
                        column: x => x.LocationAreaId,
                        principalTable: "VehicleLocationAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleLocationTowns_VehicleLocationRegions_LocationRegionId",
                        column: x => x.LocationRegionId,
                        principalTable: "VehicleLocationRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBodyTypesVehicleModels",
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
                        principalTable: "VehicleBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleBodyTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDrivetrainTypesVehicleModels",
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
                        principalTable: "VehicleDrivetrainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleDrivetrainTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleEngineTypesVehicleModels",
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
                        principalTable: "VehicleEngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleEngineTypesVehicleModels_VehicleModels_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransmissionTypesVehicleModels",
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
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleTransmissionTypesVehicleModels_VehicleTransmissionTy~",
                        column: x => x.AvailableTransmissionTypesId,
                        principalTable: "VehicleTransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "VehicleBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleDrivetrainTypes_DrivetrainTypeId",
                        column: x => x.DrivetrainTypeId,
                        principalTable: "VehicleDrivetrainTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleEngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "VehicleEngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleLocationAreas_LocationAreaId",
                        column: x => x.LocationAreaId,
                        principalTable: "VehicleLocationAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleLocationRegions_LocationRegionId",
                        column: x => x.LocationRegionId,
                        principalTable: "VehicleLocationRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleLocationTowns_LocationTownId",
                        column: x => x.LocationTownId,
                        principalTable: "VehicleLocationTowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalTable: "VehicleTransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiclesBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "VehiclesBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiclesColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "VehiclesColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
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
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePrices",
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
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_Name",
                table: "VehicleBodyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypesVehicleModels_ModelsId",
                table: "VehicleBodyTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDrivetrainTypes_Name",
                table: "VehicleDrivetrainTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDrivetrainTypesVehicleModels_ModelsId",
                table: "VehicleDrivetrainTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEngineTypes_Name",
                table: "VehicleEngineTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEngineTypesVehicleModels_ModelsId",
                table: "VehicleEngineTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleId",
                table: "VehicleImages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationAreas_LocationRegionId",
                table: "VehicleLocationAreas",
                column: "LocationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationAreas_Name",
                table: "VehicleLocationAreas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationRegions_Name",
                table: "VehicleLocationRegions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationAreaId",
                table: "VehicleLocationTowns",
                column: "LocationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_LocationRegionId",
                table: "VehicleLocationTowns",
                column: "LocationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLocationTowns_Name",
                table: "VehicleLocationTowns",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name",
                table: "VehicleModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandId",
                table: "VehicleModels",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleTypeId",
                table: "VehicleModels",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePrices_VehicleId",
                table: "VehiclePrices",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BodyTypeId",
                table: "Vehicles",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandId",
                table: "Vehicles",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DrivetrainTypeId",
                table: "Vehicles",
                column: "DrivetrainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineTypeId",
                table: "Vehicles",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationAreaId",
                table: "Vehicles",
                column: "LocationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationRegionId",
                table: "Vehicles",
                column: "LocationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationTownId",
                table: "Vehicles",
                column: "LocationTownId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionTypeId",
                table: "Vehicles",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesBrands_Name",
                table: "VehiclesBrands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesColors_Name",
                table: "VehiclesColors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransmissionTypes_Name",
                table: "VehicleTransmissionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransmissionTypesVehicleModels_ModelsId",
                table: "VehicleTransmissionTypesVehicleModels",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Name",
                table: "VehicleTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleBodyTypesVehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleDrivetrainTypesVehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleEngineTypesVehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "VehiclePrices");

            migrationBuilder.DropTable(
                name: "VehicleTransmissionTypesVehicleModels");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleBodyTypes");

            migrationBuilder.DropTable(
                name: "VehicleDrivetrainTypes");

            migrationBuilder.DropTable(
                name: "VehicleEngineTypes");

            migrationBuilder.DropTable(
                name: "VehicleLocationTowns");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleTransmissionTypes");

            migrationBuilder.DropTable(
                name: "VehiclesColors");

            migrationBuilder.DropTable(
                name: "VehicleLocationAreas");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "VehiclesBrands");

            migrationBuilder.DropTable(
                name: "VehicleLocationRegions");
        }
    }
}
