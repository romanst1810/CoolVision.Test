using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolVision.Core.Models;
using CoolVision.Data.Interfaces;
using CoolVision.Data.Services;

namespace CoolVision.Helpers
{
    public class FlightService : IFlightService
    {
        public List<BrowseRoutesModel> BrowseRoutes()
        {
            List<CountryTotalCovid> sortedCountryList = GetSortedCovidStatistics();
            List<BrowseRoutesModel> br = new List<BrowseRoutesModel>();
            ICountryService service = new CountryService();
            var places = service.GetPlaces();
            foreach (var sortedPlaces in sortedCountryList.Select(sortedCountry 
                => places.Where(x => x.CountryName == sortedCountry.CountryName)))
            {
                br.AddRange(
                    from sp 
                    in sortedPlaces 
                    where sp.PlaceName != "Israel" 
                    select service.BrowseRoutes(sp.PlaceId)
                    );
            }
            return br;
        }

        private List<CountryTotalCovid> GetSortedCovidStatistics()
        {
            List<CountryTotalCovid> ctcList = new List<CountryTotalCovid>();
            ICountryService service = new CountryService();
            var places = service.GetPlaces();
            foreach (var p in places)
            {
                var ctc = new CountryTotalCovid();
                if (p.CountryName == "United States")
                    p.CountryName = "USA";
                CovidStatistics cs = service.GetCovidStatistics(p.CountryName);
                ctc.Total = cs.response[0].cases.total;
                ctc.CountryName = p.CountryName;
                ctcList.Add(ctc);
            }
            var result = ctcList.GroupBy(x => x.Total)
                .Select(y => y.First())
                .ToList();
            return result;
        }
    }
}
