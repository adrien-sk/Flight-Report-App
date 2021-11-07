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
		private readonly FlightReportAppContext _flightReportAppContext;

		private readonly ILogger<ReportController> _logger;

		public ReportController(ILogger<ReportController> logger, FlightReportAppContext flightReportAppContext)
		{
			_logger = logger;
			_flightReportAppContext = flightReportAppContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Report>> GetAllReports()
		{
			return Ok(_flightReportAppContext.Reports.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Report> GetReportById(int id)
		{
			var report = _flightReportAppContext.Reports.FirstOrDefault(x => x.Id == id);

			if(report != null)
			{
				return Ok(report);
			}

			return NotFound();
		}
	}
}
