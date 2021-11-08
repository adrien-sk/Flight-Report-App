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
		public ActionResult<IEnumerable<Report>> GetAllReports()
		{
			return Ok(_flightReportAppDbContext.Reports.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Report> GetReportById(int id)
		{
			var report = _flightReportAppDbContext.Reports.FirstOrDefault(x => x.Id == id);

			if(report != null)
			{
				return Ok(report);
			}

			return NotFound();
		}
	}
}
