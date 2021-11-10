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
		private readonly FlightReportAppDbContext _flightReportAppDbContext;

		private readonly ILogger<FlightController> _logger;

		public FlightController(ILogger<FlightController> logger, FlightReportAppDbContext flightReportAppDbContext)
		{
			_logger = logger;
			_flightReportAppDbContext = flightReportAppDbContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Flight>> GetFlights()
		{
			return Ok(_flightReportAppDbContext.Flights.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Flight> GetFlightById(int id)
		{
			var flight = _flightReportAppDbContext.Flights.FirstOrDefault(x => x.Id == id);

			if (flight != null)
			{
				return Ok(flight);
			}

			return NotFound();
		}

		[HttpPost]
		public ActionResult<Flight> CreateAirport(Flight flight)
		{

			_flightReportAppDbContext.Flights.Add(flight);

			if (_flightReportAppDbContext.SaveChanges() > 0)
			{
				return Ok(flight);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public ActionResult<Flight> UpdateFlight(int id, Flight flight)
		{
			if (id != flight.Id)
			{
				return BadRequest();
			}

			var existingFlight = _flightReportAppDbContext.Flights.FirstOrDefault(x => x.Id == id);
			if (existingFlight == null)
			{
				return NotFound();
			}

			_flightReportAppDbContext.Flights.Update(flight);

			return Ok(flight);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteFlight(int id)
		{
			var flight = _flightReportAppDbContext.Flights.FirstOrDefault(x => x.Id == id);

			if (flight != null)
			{
				_flightReportAppDbContext.Flights.Remove(flight);
				return Ok();
			}

			return NotFound();
		}
	}
}
