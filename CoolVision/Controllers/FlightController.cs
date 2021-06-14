using System;
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
        public List<FlightModel> Get()
        {
            DateTime outboundpartialdate = new DateTime(2021, 06, 15);
            DateTime inboundpartialdate = new DateTime(2021,10,01);
            var results = _flightService.BrowseRoutes(outboundpartialdate, inboundpartialdate);
            return results;
        }
    }
}
