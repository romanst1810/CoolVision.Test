using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace CoolVision.Core.Models
{
    public class CountriesResultModel 
    {
        public string get { get; set; }
        public List<object> parameters { get; set; } = new List<object>();
        public List<object> errors { get; set; } = new List<object>();
        public int results { get; set; }
        public List<string> response { get; set; } = new List<string>();

        //public string[] Errors { get; set; }
        //public int Results { get; set; }
        //public string[] Response { get; set; }
    }
}
