using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightReportApp.API.Model
{
	[Table("Flight")]
	public class Flight
	{
		public Flight()
		{
			Reports = new HashSet<Report>();
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

		public int Id { get; set; }

		public int PlaneId { get; set; }
		public Plane Plane { get; set; }

		public int DepartureLocationId { get; set; }
		public Airport DepartureLocation { get; set; }

		public int ArrivalLocationId { get; set; }
		public Airport ArrivalLocation { get; set; }

		public DateTime? DepartureDate { get; set; }

		public DateTime? ArrivalDate { get; set; }

		[JsonIgnore]
		public virtual ICollection<Report> Reports { get; set; }
	}
}
