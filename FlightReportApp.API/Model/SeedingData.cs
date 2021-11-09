using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReportApp.API.Model
{
	public static class SeedingData
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			// Planes
			var plane1 = new Plane(1, "H520", new DateTime(2005, 5, 13, 9, 0, 0));
			var plane2 = new Plane(2, "J294", new DateTime(2007, 2, 5, 9, 0, 0));
			var plane3 = new Plane(3, "V872", new DateTime(2010, 11, 22, 9, 0, 0));

			// Airports
			var airport1 = new Airport(1, "HND", "Tokyo Haneda Airport", "Japan");
			var airport2 = new Airport(2, "DEN", "Denver International Airport", "United States");
			var airport3 = new Airport(3, "BSL", "EuroAirport Basel-Mulhouse-Freiburg", "France");

			// Flights
			var flight1 = new Flight(1, 1, 1, 2, new DateTime(2019, 5, 22, 8, 30, 0), new DateTime(2019, 5, 22, 13, 40, 0));
			var flight2 = new Flight(2, 3, 1, 3, new DateTime(2019, 5, 23, 17, 15, 0), new DateTime(2019, 5, 23, 19, 30, 0));
			var flight3 = new Flight(3, 2, 2, 1, new DateTime(2020, 10, 10, 10, 0, 0), new DateTime(2020, 10, 10, 11, 30, 0));
			var flight4 = new Flight(4, 3, 3, 2, new DateTime(2020, 10, 15, 7, 30, 0), new DateTime(2020, 10, 15, 10, 0, 0));
			var flight5 = new Flight(5, 1, 3, 1, new DateTime(2020, 11, 2, 14, 45, 0), new DateTime(2020, 11, 2, 22, 10, 0));


			modelBuilder.Entity<Plane>()
				.HasData(
					plane1, plane2, plane3
				);

			modelBuilder.Entity<Airport>()
				.HasData(
					airport1, airport2, airport3
				);

			modelBuilder.Entity<Flight>()
				.HasData(
					flight1, flight2, flight3, flight4, flight5
				);
		}
	}
}
