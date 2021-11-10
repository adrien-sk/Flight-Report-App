using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightReportApp.API.Model
{
	[Table("Airport")]
	public class Airport
	{
		public Airport()
		{
			DepartureFlights = new HashSet<Flight>();
			ArrivalFlights = new HashSet<Flight>();
		}

		public Airport(int id, string code, string name, string country)
		{
			Id = id;
			Code = code;
			Name = name;
			Country = country;
		}

		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }

		[JsonIgnore]
		public virtual ICollection<Flight> DepartureFlights { get; set; }
		[JsonIgnore]
		public virtual ICollection<Flight> ArrivalFlights { get; set; }
	}
}
