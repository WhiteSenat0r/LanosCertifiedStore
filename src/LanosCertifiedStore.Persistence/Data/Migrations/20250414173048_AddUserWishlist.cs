using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanosCertifiedStore.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WishlistId",
                schema: "identity",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserWishlists",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWishlists_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesWishlists",
                schema: "vehicles",
                columns: table => new
                {
                    VehiclesId = table.Column<Guid>(type: "uuid", nullable: false),
                    WishlistsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesWishlists", x => new { x.VehiclesId, x.WishlistsId });
                    table.ForeignKey(
                        name: "FK_VehiclesWishlists_UserWishlists_WishlistsId",
                        column: x => x.WishlistsId,
                        principalSchema: "identity",
                        principalTable: "UserWishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclesWishlists_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalSchema: "vehicles",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWishlists_UserId",
                schema: "identity",
                table: "UserWishlists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesWishlists_WishlistsId",
                schema: "vehicles",
                table: "VehiclesWishlists",
                column: "WishlistsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesWishlists",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "UserWishlists",
                schema: "identity");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                schema: "identity",
                table: "Users");
        }
    }
}
