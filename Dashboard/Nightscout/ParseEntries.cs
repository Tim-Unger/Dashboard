using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using System.Windows.Navigation;
using Newtonsoft.Json;

namespace Dashboard.Nightscout
{
    internal class ParseEntries
    {
        public static Entry GetNewestEntry(string data)
        {
            var jsonList = JsonConvert.DeserializeObject<List<NightscoutEntry>>(data);
            if(jsonList == null)
            {
                throw new Exception();
            }

            NightscoutEntry nightscoutEntry = jsonList[0];

            int hours = nightscoutEntry.UtcOffset / 60;
            DateTime entryTime = nightscoutEntry.DateString.AddHours(hours);
            int value = nightscoutEntry.Sgv;
            var delta = Math.Round(nightscoutEntry.Delta, 0);
            string directionString = nightscoutEntry.Direction;
            Direction direction = directionString switch
            {
                "Flat" => Direction.Flat,
                "FortyFiveUp" => Direction.FortyFiveUp,
                "SingleUp" => Direction.OneUp,
                "DoubleUp" => Direction.TwoUp,
                "FortyFiveDown" => Direction.FortyFiveDown,
                "SingleDown" => Direction.OneDown,
                "DoubleDown" => Direction.TwoDown,
                _ => throw new Exception()
            };

            Entry entry = new()
            {
                Date = entryTime,
                Value = value,
                Direction = direction,
                Delta = Convert.ToInt32(delta),
                DirectionString = directionString
            };

            return entry;
        }
        public static List<Entry> GetAllEntries(string data)
        {
            List<NightscoutEntry>? entries = JsonConvert.DeserializeObject<List<NightscoutEntry>>(data);

            if (entries == null )
            {
                return Enumerable.Empty<Entry>().ToList();
            }

            return new List<Entry>();
        }
    }
}
