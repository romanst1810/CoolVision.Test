using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CoolVision.Core.Models;
using CoolVision.Data.Interfaces;
using CoolVision.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolVision.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetSortedCovidStatistics()
        {
            List<CountryTotalCovid> ctcList = new List<CountryTotalCovid>();
            ICountryService service = new CountryService();
            var places = service.GetPlaces();
            foreach (var p in places)
            {
                var ctc = new CountryTotalCovid {CountryName = p.CountryName};
                if (p.CountryName == "United States")
                    p.CountryName = "USA";
                CovidStatistics cs = service.GetCovidStatistics(p.CountryName);
                ctc.Total = cs.response[0].cases.total;
                ctcList.Add(ctc);
            }
            var result = ctcList.GroupBy(x => x.Total)
                .Select(y => y.First())
                .ToList();
            Assert.IsTrue(result.Any());
        }
        
        [TestMethod]
        public void GetPlaces()
        {
            ICountryService service = new CountryService();
            var res = service.GetPlaces();
            Assert.IsTrue(res.Any());
        }

        [TestMethod]
        public void BrouseRoutes()
        {
            List<BrowseRoutesModel> br = new List<BrowseRoutesModel>();
            ICountryService service = new CountryService();
            var res = service.GetPlaces();
            foreach (var p in res)
            {
                if (p.PlaceName == "Israel")
                    continue;
                BrowseRoutesModel a = service.BrowseRoutes(p.PlaceId);
                br.Add(a);
            }

            Assert.IsTrue(br.Any());
        }
    }
}
