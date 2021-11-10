using FlightReportApp.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReportApp.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ReportController : ControllerBase
	{
		private readonly FlightReportAppDbContext _flightReportAppDbContext;

		private readonly ILogger<ReportController> _logger;

		public ReportController(ILogger<ReportController> logger, FlightReportAppDbContext flightReportAppDbContext)
		{
			_logger = logger;
			_flightReportAppDbContext = flightReportAppDbContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Report>> GetReports()
		{
			return Ok(_flightReportAppDbContext.Reports.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Report> GetReportById(int id)
		{
			var report = _flightReportAppDbContext.Reports.FirstOrDefault(x => x.Id == id);

			if (report != null)
			{
				return Ok(report);
			}

			return NotFound();
		}

		[HttpPost]
		public ActionResult<Report> CreateAirport(Report report)
		{

			_flightReportAppDbContext.Reports.Add(report);

			if (_flightReportAppDbContext.SaveChanges() > 0)
			{
				return Ok(report);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public ActionResult<Report> UpdateReport(int id, Report report)
		{
			if (id != report.Id)
			{
				return BadRequest();
			}

			var existingReport = _flightReportAppDbContext.Reports.FirstOrDefault(x => x.Id == id);
			if (existingReport == null)
			{
				return NotFound();
			}

			_flightReportAppDbContext.Reports.Update(report);

			return Ok(report);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteReport(int id)
		{
			var report = _flightReportAppDbContext.Reports.FirstOrDefault(x => x.Id == id);

			if (report != null)
			{
				_flightReportAppDbContext.Reports.Remove(report);
				return Ok();
			}

			return NotFound();
		}
	}
}
