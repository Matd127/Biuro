using Microsoft.EntityFrameworkCore.Migrations;

namespace Biuro_Podrozy.Migrations
{
    public partial class migracja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dc",
                columns: table => new
                {
                    DepartureCityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dc", x => x.DepartureCityId);
                });

            migrationBuilder.CreateTable(
                name: "BiuroItemDepartureCity",
                columns: table => new
                {
                    BiuroItemsId = table.Column<int>(type: "int", nullable: false),
                    DepartureCitiesDepartureCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiuroItemDepartureCity", x => new { x.BiuroItemsId, x.DepartureCitiesDepartureCityId });
                    table.ForeignKey(
                        name: "FK_BiuroItemDepartureCity_Data_BiuroItemsId",
                        column: x => x.BiuroItemsId,
                        principalTable: "Data",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiuroItemDepartureCity_Dc_DepartureCitiesDepartureCityId",
                        column: x => x.DepartureCitiesDepartureCityId,
                        principalTable: "Dc",
                        principalColumn: "DepartureCityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiuroItemDepartureCity_DepartureCitiesDepartureCityId",
                table: "BiuroItemDepartureCity",
                column: "DepartureCitiesDepartureCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiuroItemDepartureCity");

            migrationBuilder.DropTable(
                name: "Dc");
        }
    }
}
