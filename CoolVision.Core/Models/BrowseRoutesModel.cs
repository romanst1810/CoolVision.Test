using System;
using System.Collections.Generic;
using System.Text;

namespace CoolVision.Core.Models
{
    public class OutboundLeg
    {
        public List<int> CarrierIds { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class Quote
    {
        public int QuoteId { get; set; }
        public int MinPrice { get; set; }
        public bool Direct { get; set; }
        public OutboundLeg OutboundLeg { get; set; }
        public DateTime QuoteDateTime { get; set; }
    }

    public class Carrier
    {
        public int CarrierId { get; set; }
        public string Name { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public bool SymbolOnLeft { get; set; }
        public bool SpaceBetweenAmountAndSymbol { get; set; }
        public int RoundingCoefficient { get; set; }
        public int DecimalDigits { get; set; }
    }

    public class Route
    {
        public int Price { get; set; }
        public DateTime QuoteDateTime { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public List<int> QuoteIds { get; set; }
    }

    public class BrowseRoutesModel
    {
        public List<Quote> Quotes { get; set; }
        public List<Carrier> Carriers { get; set; }
        public List<Place> Places { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Route> Routes { get; set; }
    }

}
