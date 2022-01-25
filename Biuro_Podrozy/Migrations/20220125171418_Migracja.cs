using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biuro_Podrozy.Migrations
{
    public partial class Migracja : Migration
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
                name: "Ph",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ph", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    TravelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotosPhotoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_Ph_PhotosPhotoId",
                        column: x => x.PhotosPhotoId,
                        principalTable: "Ph",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Data_PhotosPhotoId",
                table: "Data",
                column: "PhotosPhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiuroItemDepartureCity");

            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "Dc");

            migrationBuilder.DropTable(
                name: "Ph");
        }
    }
}
