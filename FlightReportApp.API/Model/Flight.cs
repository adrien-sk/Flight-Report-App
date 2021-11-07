using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Flight")]
	public class Flight
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("plane_id")]
		public int PlaneId { get; set; }

		[Column("departure_location")]
		public Airport DepartureLocation { get; set; }

		[Column("arrival_location")]
		public Airport ArrivalLocation { get; set; }

		[Column("departure_date")]
		public DateTime? DepartureDate { get; set; }

		[Column("arrival_date")]
		public DateTime? ArrivalDate { get; set; }
	}
}
