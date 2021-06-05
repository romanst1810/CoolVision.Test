using CoolVision.Core.Models;
using CoolVision.Data.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace CoolVision.Data.Services
{
    public class CountryService : ICountryService
    {
        public CountriesResultModel GetCovid()
        {
            var client = new RestClient("https://covid-193.p.rapidapi.com/countries");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "36ab0bc21dmsh18fedac8662b2eap13bd61jsnf3984c20d5af");
            request.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            CountriesResultModel resultModel = JsonConvert.DeserializeObject<CountriesResultModel>(response.Content);
            return resultModel;
        }

        public CountriesResultModel GetFlights()
        {
            var client = new RestClient(
                "https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/apiservices/referral/v1.0/%7Bcountry%7D/%7Bcurrency%7D/%7Blocale%7D/%7Boriginplace%7D/%7Bdestinationplace%7D/%7Boutboundpartialdate%7D/%7Binboundpartialdate%7D?shortapikey=ra66933236979928&apiKey=%7Bshortapikey%7D");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "36ab0bc21dmsh18fedac8662b2eap13bd61jsnf3984c20d5af");
            request.AddHeader("x-rapidapi-host", "skyscanner-skyscanner-flight-search-v1.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            CountriesResultModel resultModel = JsonConvert.DeserializeObject<CountriesResultModel>(response.Content);
            return resultModel;
        }
    }
}
