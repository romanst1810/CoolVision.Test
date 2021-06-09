using System;
using System.Collections.Generic;
using System.Text;
using CoolVision.Core.Models;
using RestSharp;

namespace CoolVision.Data.Interfaces
{
    public interface ICountryService
    {
        List<Place> GetPlaces();
        CovidStatistics GetCovidStatistics(string country);
        BrowseRoutesModel BrowseRoutes(string destinationPlace);
    }
}
