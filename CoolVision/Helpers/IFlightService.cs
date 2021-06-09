using System.Collections.Generic;
using CoolVision.Core.Models;

namespace CoolVision.Helpers
{
    public interface IFlightService
    {
        List<BrowseRoutesModel> BrowseRoutes();
    }
}