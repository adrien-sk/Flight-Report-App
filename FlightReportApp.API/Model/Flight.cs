using System;
using System.Collections.Generic;
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

		public Plane Plane { get; set; }

		[Column("departure_location_id")]
		public int DepartureLocationId { get; set; }
		public Airport DepartureLocation { get; set; }

		[Column("arrival_location_id")]
		public int ArrivalLocationId { get; set; }
		public Airport ArrivalLocation { get; set; }

		[Column("departure_date")]
		public DateTime? DepartureDate { get; set; }

		[Column("arrival_date")]
		public DateTime? ArrivalDate { get; set; }

		public List<Report> Reports { get; set; }
	}
}
