using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.VVS
{
    enum TrainType
    {
        SBahn,
        UBahn,
        Bus,
        Regionalbahn
    }

    class VVSTimetable
    {
        public DateTime RequestTime { get; set; }
        public string Station { get; set; }

        public List<Departure>? Departures { get; set; }
    }

    class Departure
    {
        public int Countdown { get; set; }
        public DateTime DepartureTime { get; set; }
        public int Delay { get; set; }
        public string Platform { get; set; }
        public string Line { get; set; }
        public string Terminus { get; set; }
        public string DepartureStation { get; set; }
        public TrainType TrainType { get; set; }
    }
}
