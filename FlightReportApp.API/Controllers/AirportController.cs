using FlightReportApp.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace FlightReportApp.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class AirportController : ControllerBase
	{
		private readonly FlightReportAppDbContext _flightReportAppDbContext;
		private readonly ILogger<AirportController> _logger;

		public AirportController(ILogger<AirportController> logger, FlightReportAppDbContext flightReportAppDbContext)
		{
			_logger = logger;
			_flightReportAppDbContext = flightReportAppDbContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Airport>> GetAirports()
		{
			return Ok(_flightReportAppDbContext.Airports.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Airport> GetAirportById(int id)
		{
			var airport = _flightReportAppDbContext.Airports.FirstOrDefault(x => x.Id == id);

			if(airport != null)
			{
				return Ok(airport);
			}

			return NotFound();
		}

		[HttpPost]
		public ActionResult<Airport> CreateAirport(Airport airport)
		{

			_flightReportAppDbContext.Airports.Add(airport);

			if (_flightReportAppDbContext.SaveChanges() > 0)
			{
				return Ok(airport);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public ActionResult<Airport> UpdateAirport(int id, Airport airport)
		{
			if (id != airport.Id)
			{
				return BadRequest();
			}

			var existingAirport = _flightReportAppDbContext.Airports.FirstOrDefault(x => x.Id == id);
			if (existingAirport == null)
			{
				return NotFound();
			}

			//Maybe buggy
			_flightReportAppDbContext.Airports.Update(airport);

			return Ok(airport);
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteAirport(int id)
		{
			var airport = _flightReportAppDbContext.Airports.FirstOrDefault(x => x.Id == id);

			if (airport != null)
			{
				_flightReportAppDbContext.Airports.Remove(airport);
				return Ok();
			}
			
			return NotFound();
		}
	}
}
