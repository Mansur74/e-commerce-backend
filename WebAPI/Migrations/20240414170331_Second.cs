using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopReviews",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopReviews", x => new { x.UserId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_ShopReviews_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RateUserId = table.Column<int>(type: "int", nullable: false),
                    RateShopId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopRates_ShopReviews_RateUserId_RateShopId",
                        columns: x => new { x.RateUserId, x.RateShopId },
                        principalTable: "ShopReviews",
                        principalColumns: new[] { "UserId", "ShopId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopRates_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopRates_RateUserId_RateShopId",
                table: "ShopRates",
                columns: new[] { "RateUserId", "RateShopId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopRates_ShopId",
                table: "ShopRates",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopRates_UserId",
                table: "ShopRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReviews_ShopId",
                table: "ShopReviews",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopRates");

            migrationBuilder.DropTable(
                name: "ShopReviews");
        }
    }
}
