using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Nightscout
{
    public class Entries
    {
        public NightscoutEntry[] Entry { get; set; }
    }

    public class NightscoutEntry
    {
        public string _Id { get; set; }
        public string Device { get; set; }
        public long Date { get; set; }
        public DateTime DateString { get; set; }
        public int Sgv { get; set; }
        public float Delta { get; set; }
        public string Direction { get; set; }
        public string Type { get; set; }
        public int Filtered { get; set; }
        public int Unfiltered { get; set; }
        public int Rssi { get; set; }
        public int Noise { get; set; }
        public DateTime SysTime { get; set; }
        public int UtcOffset { get; set; }
        public long Mills { get; set; }
    }

    public enum Direction
    {
        Flat,
        FortyFiveUp,
        OneUp,
        TwoUp,
        FortyFiveDown,
        OneDown,
        TwoDown,
    }

    public class Entry
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int Delta { get; set; }
        public string DirectionString { get; set; }
        public Direction Direction { get; set; }
    }
}
