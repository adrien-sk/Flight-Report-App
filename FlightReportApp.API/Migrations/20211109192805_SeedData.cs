﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightReportApp.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airport",
                columns: new[] { "id", "code", "country", "name" },
                values: new object[,]
                {
                    { 1, "HND", "Japan", "Tokyo Haneda Airport" },
                    { 2, "DEN", "United States", "Denver International Airport" },
                    { 3, "BSL", "France", "EuroAirport Basel-Mulhouse-Freiburg" }
                });

            migrationBuilder.InsertData(
                table: "Plane",
                columns: new[] { "id", "code", "first_use_date" },
                values: new object[,]
                {
                    { 1, "H520", new DateTime(2005, 5, 13, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "J294", new DateTime(2007, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "V872", new DateTime(2010, 11, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "id", "arrival_date", "arrival_location_id", "departure_date", "departure_location_id", "plane_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 5, 22, 13, 40, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 5, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 5, new DateTime(2020, 11, 2, 22, 10, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 2, 14, 45, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 3, new DateTime(2020, 10, 10, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 10, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 2, new DateTime(2019, 5, 23, 19, 30, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 5, 23, 17, 15, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2020, 10, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 10, 15, 7, 30, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Airport",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airport",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airport",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plane",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plane",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plane",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
