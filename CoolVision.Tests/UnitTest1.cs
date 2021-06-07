using System.Linq;
using CoolVision.Data.Interfaces;
using CoolVision.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolVision.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCovidCountries()
        {
            ICountryService service = new CountryService();
            var res = service.GetCovid();
            Assert.IsTrue(res.response.Any());
        }
        
        [TestMethod]
        public void GetFlightsCountries()
        {
            ICountryService service = new CountryService();
            var res = service.GetFlights();
            Assert.IsTrue(res.response.Any());
        }
        [TestMethod]
        public void GetFlightsToFrance()
        {
            ICountryService service = new CountryService();
            var res = service.GetFlightsToFrance();
            Assert.IsTrue(res.response.Any());
        }
       
    }
}
