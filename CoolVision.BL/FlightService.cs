using System;
using System.Collections.Generic;
using System.Linq;
using CoolVision.Core.Models;
using CoolVision.Data.Interfaces;

namespace CoolVision.BL
{
    public class FlightService : IFlightService
    {
        private ICountryService _service;
        public FlightService(ICountryService service)
        {
            this._service = service;
        }

        public List<FlightModel> BrowseRoutes(DateTime outboundpartialdate,
            DateTime inboundpartialdate)
        {
            List<CountryTotalCovid> sortedCountryList = GetSortedCovidStatistics();
            List<BrowseRoutesModel> br = new List<BrowseRoutesModel>();
            var places = _service.GetPlaces();
            foreach (var sortedPlaces in sortedCountryList.Select(sortedCountry
                => places.Where(x => x.CountryName == sortedCountry.CountryName)))
            {
                br.AddRange(
                    from sp
                    in sortedPlaces
                    where sp.PlaceName != "Israel"
                    select _service.BrowseRoutes(sp.PlaceId, outboundpartialdate, inboundpartialdate)
                    );
            }
            var result = br.Where(x=>x.Places.Any()).Select(x => GetFlight(x, sortedCountryList)).ToList();
            return result;
        }

        public FlightModel GetFlight(BrowseRoutesModel req, List<CountryTotalCovid> sortedCountryList)
        {
            FlightModel fm = new FlightModel();
            fm.CountryName = req.Places[0].CountryName;
            fm.MinPrice = req.Quotes[0].MinPrice;
            fm.QuoteDateTime = req.Quotes[0].QuoteDateTime;
            fm.CovidTotal = sortedCountryList.
                First(x => x.CountryName.ToLower() == fm.CountryName.ToLower()).Total;
            return fm;
        }


        private List<CountryTotalCovid> GetSortedCovidStatistics()
        {
            List<CountryTotalCovid> ctcList = new List<CountryTotalCovid>();
            var places = _service.GetPlaces();
            foreach (var p in places)
            {
                var ctc = new CountryTotalCovid();
                if (p.CountryName == "United States")
                    p.CountryName = "USA";
                CovidStatistics cs = _service.GetCovidStatistics(p.CountryName);
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
