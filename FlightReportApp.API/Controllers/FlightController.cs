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
	public class FlightController : ControllerBase
	{
		private readonly FlightReportAppDbContext _flightReportAppContext;

		private readonly ILogger<FlightController> _logger;

		public FlightController(ILogger<FlightController> logger, FlightReportAppDbContext flightReportAppContext)
		{
			_logger = logger;
			_flightReportAppContext = flightReportAppContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Flight>> GetAllFlights()
		{
			return Ok(_flightReportAppContext.Flights.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Flight> GetFlightById(int id)
		{
			var flight = _flightReportAppContext.Flights.FirstOrDefault(x => x.Id == id);

			if(flight != null)
			{
				return Ok(flight);
			}

			return NotFound();
		}
	}
}
