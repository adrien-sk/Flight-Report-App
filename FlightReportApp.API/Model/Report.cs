using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReportApp.API.Model
{
	[Table("Report")]
	public class Report
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("reporter_id")]
		public int ReporterId { get; set; }

		[Column("flight_id")]
		public int FlightId { get; set; }
		public Flight Flight { get; set; }
	}
}
