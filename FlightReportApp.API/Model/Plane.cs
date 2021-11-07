using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Plane")]
	public class Plane
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("code")]
		public string Code { get; set; }

		[Column("first_use_date")]
		public DateTime? FirstUseDate { get; set; }
	}
}
