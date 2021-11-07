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
	[Route("api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly FlightReportAppContext _flightReportAppContext;

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, FlightReportAppContext flightReportAppContext)
		{
			_logger = logger;
			_flightReportAppContext = flightReportAppContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Plane>> Get()
		{
			return Ok(_flightReportAppContext.Planes.ToList());
		}
	}
}
