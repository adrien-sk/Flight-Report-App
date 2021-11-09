using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReportApp.API.Model
{
	public class FlightReportAppDbContext : DbContext
	{
		public FlightReportAppDbContext(DbContextOptions<FlightReportAppDbContext> options)
		: base(options)
		{
		}

		public DbSet<Plane> Planes { get; set; }
		public DbSet<Airport> Airports { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<Report> Reports { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Flight>()
				.HasOne(f => f.Plane)
				.WithMany(p => p.Flights)
				.HasForeignKey(f => f.PlaneId);

			modelBuilder.Entity<Flight>()
				.HasOne(f => f.DepartureLocation)
				.WithMany(dl => dl.DepartureFlights)
				.HasForeignKey(f => f.DepartureLocationId)
                .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Flight>()
				.HasOne(f => f.ArrivalLocation)
				.WithMany(al => al.ArrivalFlights)
				.HasForeignKey(f => f.ArrivalLocationId)
                .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Report>()
				.HasOne(r => r.Flight)
				.WithMany(r => r.Reports)
				.HasForeignKey(r => r.FlightId);

			modelBuilder.Seed();
		}

	}
}
