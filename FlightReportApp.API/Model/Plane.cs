using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Plane")]
	public class Plane
	{
		public Plane()
		{

		}

		public Plane(int id, string code, DateTime firstUseDate)
		{
			Id = id;
			Code = code;
			FirstUseDate = firstUseDate;
		}

		[Column("id")]
		public int Id { get; set; }

		[Column("code")]
		public string Code { get; set; }

		[Column("first_use_date")]
		public DateTime? FirstUseDate { get; set; }

		public virtual ICollection<Flight> Flights { get; set; }
	}
}
