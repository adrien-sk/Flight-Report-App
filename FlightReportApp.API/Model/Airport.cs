using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Airport")]
	public class Airport
	{
		public Airport()
		{

		}

		public Airport(int id, string code, string name, string country)
		{
			Id = id;
			Code = code;
			Name = name;
			Country = country;
		}

		[Column("id")]
		public int Id { get; set; }

		[Column("code")]
		public string Code { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("country")]
		public string Country { get; set; }

		public virtual ICollection<Flight> DepartureFlights { get; set; }
		public virtual ICollection<Flight> ArrivalFlights { get; set; }
	}
}
