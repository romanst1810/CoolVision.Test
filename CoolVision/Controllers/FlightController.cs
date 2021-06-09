using CoolVision.BL;
using CoolVision.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoolVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            this._flightService = flightService;
        }

        // GET: api/<FlightController>
        [HttpGet]
        public List<BrowseRoutesModel> Get()
        {
            return _flightService.BrowseRoutes();
        }
    }
}
