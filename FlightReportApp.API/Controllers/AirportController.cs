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
	public class AirportController : ControllerBase
	{
		private readonly FlightReportAppContext _flightReportAppContext;

		private readonly ILogger<AirportController> _logger;

		public AirportController(ILogger<AirportController> logger, FlightReportAppContext flightReportAppContext)
		{
			_logger = logger;
			_flightReportAppContext = flightReportAppContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Airport>> GetAllAirports()
		{
			return Ok(_flightReportAppContext.Airports.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Airport> GetAirportById(int id)
		{
			var airport = _flightReportAppContext.Airports.FirstOrDefault(x => x.Id == id);

			if(airport != null)
			{
				return Ok(airport);
			}

			return NotFound();
		}
	}
}
