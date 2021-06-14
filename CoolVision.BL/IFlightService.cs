using System;
using System.Collections.Generic;
using CoolVision.Core.Models;

namespace CoolVision.BL
{
    public interface IFlightService
    {
        List<FlightModel> BrowseRoutes(DateTime outboundpartialdate,
            DateTime inboundpartialdate);
    }
}