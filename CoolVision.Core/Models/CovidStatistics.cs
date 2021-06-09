using System;
using System.Collections.Generic;
using System.Text;

namespace CoolVision.Core.Models
{
    public class CovidStatistics
    {
        public string get { get; set; }
        public Parameters parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public List<Response> response { get; set; }
    }
    public class Parameters
    {
        public string country { get; set; }
    }

    public class Cases
    {
        public string @new { get; set; }
        public int active { get; set; }
        public int critical { get; set; }
        public int recovered { get; set; }
        public string _1M_pop { get; set; }
        public int total { get; set; }
    }

    public class Deaths
    {
        public string @new { get; set; }
        public string _1M_pop { get; set; }
        public int total { get; set; }
    }

    public class Tests
    {
        public string _1M_pop { get; set; }
        public int total { get; set; }
    }

    public class Response
    {
        public string continent { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public Cases cases { get; set; }
        public Deaths deaths { get; set; }
        public Tests tests { get; set; }
        public string day { get; set; }
        public DateTime time { get; set; }
    }
}
