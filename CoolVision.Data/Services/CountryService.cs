using System;
using System.Collections.Generic;
using CoolVision.Core.Models;
using CoolVision.Data.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace CoolVision.Data.Services
{
    public class CountryService : ICountryService
    {
        public List<Place> GetPlaces()
        {
            var client = new RestClient("https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/apiservices/autosuggest/v1.0/IL/USD/en-US/?query=IL");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "36ab0bc21dmsh18fedac8662b2eap13bd61jsnf3984c20d5af");
            request.AddHeader("x-rapidapi-host", "skyscanner-skyscanner-flight-search-v1.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            PlacesModel resultModel = JsonConvert.DeserializeObject<PlacesModel>(response.Content);
            return resultModel != null ? resultModel.Places : new List<Place>();
           
        }
        public CovidStatistics GetCovidStatistics(string country)
        {
            var client = new RestClient($"https://covid-193.p.rapidapi.com/statistics?country={country}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "36ab0bc21dmsh18fedac8662b2eap13bd61jsnf3984c20d5af");
            request.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            CovidStatistics resultModel = JsonConvert.DeserializeObject<CovidStatistics>(response.Content);
            return resultModel;
        }

        public BrowseRoutesModel BrowseRoutes(string destinationPlace,DateTime outboundpartialdate,DateTime inboundpartialdate)
        {
            var client = new RestClient($"https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/" +
                                        $"apiservices/browseroutes/v1.0/IL/USD/en-US/IL-sky/{destinationPlace}/" +
                                        $"{outboundpartialdate:yyyy-MM-dd}?" +
                                        $"inboundpartialdate={inboundpartialdate:yyyy-MM-dd}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "36ab0bc21dmsh18fedac8662b2eap13bd61jsnf3984c20d5af");
            request.AddHeader("x-rapidapi-host", "skyscanner-skyscanner-flight-search-v1.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            BrowseRoutesModel resultModel = JsonConvert.DeserializeObject<BrowseRoutesModel>(response.Content);
            return resultModel;
        }
    }
}
