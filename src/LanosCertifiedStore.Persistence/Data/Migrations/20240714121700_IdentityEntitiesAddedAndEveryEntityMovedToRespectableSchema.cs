using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityEntitiesAddedAndEveryEntityMovedToRespectableSchema : Migration
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
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "UserRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1ee7e820-fa7f-46c6-bb74-ec7c7c91e3a8"), null, "Адміністратор", null },
                    { new Guid("9d11e1bd-9ba9-4489-a318-3c4c9332d8c0"), null, "Менеджер", null },
                    { new Guid("daf9f7e7-88d0-47c8-8498-53813d5ebe1a"), null, "Користувач", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                schema: "vehicles",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Name",
                schema: "identity",
                table: "UserRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "identity",
                table: "UserRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                schema: "identity",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "identity");

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
