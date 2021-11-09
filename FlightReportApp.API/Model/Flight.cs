using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Flight")]
	public class Flight
	{
		public Flight()
		{

		}

		public Flight(int id, int planeId, int departureLocationId, int arrivalLocationId, DateTime departureDate, DateTime arrivalDate)
		{
			Id = id;
			PlaneId = planeId;
			DepartureLocationId = departureLocationId;
			ArrivalLocationId = arrivalLocationId;
			DepartureDate = departureDate;
			ArrivalDate = arrivalDate;
		}

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

		public virtual ICollection<Report> Reports { get; set; }
	}
}
