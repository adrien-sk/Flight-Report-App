using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReportApp.API.Model
{
	public class FlightReportAppContext : DbContext
	{
		public FlightReportAppContext(DbContextOptions<FlightReportAppContext> options)
		: base(options)
		{
		}

		public DbSet<Plane> Planes { get; set; }
		public DbSet<Airport> Airports { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<Report> Reports { get; set; }
	}
}
