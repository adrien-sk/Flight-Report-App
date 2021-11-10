using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightReportApp.API.Model
{
	[Table("Plane")]
	public class Plane
	{
		public Plane()
		{
			Flights = new HashSet<Flight>();
		}

		public Plane(int id, string code, DateTime firstUseDate)
		{
			Id = id;
			Code = code;
			FirstUseDate = firstUseDate;
		}

		public int Id { get; set; }
		public string Code { get; set; }
		public DateTime? FirstUseDate { get; set; }

		[JsonIgnore]
		public virtual ICollection<Flight> Flights { get; set; }
	}
}
