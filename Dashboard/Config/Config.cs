using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ConfigClass
{
    public class Config
    {
        public string Language { get; set; }
        public string Station { get; set; }
        public string[]/*(string RouteStart, string RouteEnd)*/ Route { get; set; }
        public string WeatherKey { get; set; }
        public long WeatherStationId { get; set; }
        public int TimeToStation { get; set; }
        public string[]/*(int Minutes, int Seconds)*/ Timer1Time { get; set; }
        public string[]/*(int Minutes, int Seconds)*/ Timer2Time { get; set; }
        public string ClientId { get; set; }
        public string ClientKey { get; set; }
    }
}