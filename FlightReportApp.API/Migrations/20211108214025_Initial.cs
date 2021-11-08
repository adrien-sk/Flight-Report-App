using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightReportApp.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_use_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plane_id = table.Column<int>(type: "int", nullable: false),
                    departure_location_id = table.Column<int>(type: "int", nullable: false),
                    arrival_location_id = table.Column<int>(type: "int", nullable: false),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    arrival_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.id);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_arrival_location_id",
                        column: x => x.arrival_location_id,
                        principalTable: "Airport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_departure_location_id",
                        column: x => x.departure_location_id,
                        principalTable: "Airport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Plane_plane_id",
                        column: x => x.plane_id,
                        principalTable: "Plane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reporter_id = table.Column<int>(type: "int", nullable: false),
                    flight_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                    table.ForeignKey(
                        name: "FK_Report_Flight_flight_id",
                        column: x => x.flight_id,
                        principalTable: "Flight",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_arrival_location_id",
                table: "Flight",
                column: "arrival_location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_departure_location_id",
                table: "Flight",
                column: "departure_location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_plane_id",
                table: "Flight",
                column: "plane_id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_flight_id",
                table: "Report",
                column: "flight_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Plane");
        }
    }
}
