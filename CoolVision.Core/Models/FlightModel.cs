using System;
using System.Collections.Generic;
using System.Text;

namespace CoolVision.Core.Models
{
    public class FlightModel
    {
        public string CountryName { get; set; }
        public DateTime QuoteDateTime { get; set; }
        public decimal MinPrice { get; set; }
        public int CovidTotal { get; set; }
    }
}
