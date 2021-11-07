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
	}
}
