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
	public class PlaneController : ControllerBase
	{
		private readonly FlightReportAppDbContext _flightReportAppDbContext;

		private readonly ILogger<PlaneController> _logger;

		public PlaneController(ILogger<PlaneController> logger, FlightReportAppDbContext flightReportAppDbContext)
		{
			_logger = logger;
			_flightReportAppDbContext = flightReportAppDbContext;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Plane>> GetPlanes()
		{
			return Ok(_flightReportAppDbContext.Planes.ToList());
		}

		[HttpGet("{id}")]
		public ActionResult<Plane> GetPlaneById(int id)
		{
			var plane = _flightReportAppDbContext.Planes.FirstOrDefault(x => x.Id == id);

			if (plane != null)
			{
				return Ok(plane);
			}

			return NotFound();
		}

		[HttpPost]
		public ActionResult<Plane> CreateAirport(Plane plane)
		{

			_flightReportAppDbContext.Planes.Add(plane);

			if (_flightReportAppDbContext.SaveChanges() > 0)
			{
				return Ok(plane);
			}

			return BadRequest();
		}

		[HttpPut("{id}")]
		public ActionResult<Plane> UpdatePlane(int id, Plane plane)
		{
			if (id != plane.Id)
			{
				return BadRequest();
			}

			var existingPlane = _flightReportAppDbContext.Planes.FirstOrDefault(x => x.Id == id);
			if (existingPlane == null)
			{
				return NotFound();
			}

			_flightReportAppDbContext.Planes.Update(plane);

			return Ok(plane);
		}

		[HttpDelete("{id}")]
		public ActionResult DeletePlane(int id)
		{
			var plane = _flightReportAppDbContext.Planes.FirstOrDefault(x => x.Id == id);

			if (plane != null)
			{
				_flightReportAppDbContext.Planes.Remove(plane);
				return Ok();
			}

			return NotFound();
		}
	}
}
