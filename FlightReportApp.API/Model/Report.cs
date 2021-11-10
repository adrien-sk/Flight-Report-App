using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Report")]
	public class Report
	{
		public Report()
		{

		}

		public Report(int id, int reporterId, int flightId, string description)
		{
			Id = id;
			ReporterId = reporterId;
			FlightId = flightId;
			Description = description;
		}

		public int Id { get; set; }
		public int ReporterId { get; set; }
		public int FlightId { get; set; }
		public Flight Flight { get; set; }
		public string Description { get; set; }
	}
}
