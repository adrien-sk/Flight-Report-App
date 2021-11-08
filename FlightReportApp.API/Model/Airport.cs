using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Airport")]
	public class Airport
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("code")]
		public string Code { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("country")]
		public string Country { get; set; }

		public List<Flight> Flights { get; set; }
	}
}
