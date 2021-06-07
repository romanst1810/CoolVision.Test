using System;
using System.Collections.Generic;
using System.Text;
using CoolVision.Core.Models;
using RestSharp;

namespace CoolVision.Data.Interfaces
{
    public interface ICountryService
    {
        CountriesResultModel GetFlights();
        CountriesResultModel GetCovid();
        CountriesResultModel GetFlightsToFrance();
        CountriesResultModel GetFlightsToUnitedKingdom();
        CountriesResultModel GetFlightsToUnitedStates();
        CountriesResultModel GetFlightsToAustralia();
    }
}
