using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Dashboard.VVS
{
    class ParseVVS
    {
        public static VVSTimetable ParseVVSClass(string input)
        {
            VVSTimetable vVSTimetable = new();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(input);

            var requestTime = xmlDocument.SelectSingleNode("/itdRequest").Attributes["now"].Value;

            //TODO
            //vVSTimetable.Station = xmlDocument.SelectSingleNode("/itdRequest").Attributes["station"].InnerText;

            var timeRegexGroups = new Regex("([0-9]{4})-([0-9]{2})-([0-9]{2})T([0-9]{2}):([0-9]{2}):([0-9]{2})").Match(requestTime).Groups;

            vVSTimetable.RequestTime = GetDate(timeRegexGroups);
            var departures = xmlDocument.SelectSingleNode("/itdRequest/itdDepartureMonitorRequest/itdDepartureList");

            if(departures == null)
            {
                throw new Exception();
            }

            List<Departure> departureList = new();
            foreach (XmlNode departure in departures.ChildNodes)
            {
                Departure dep = new();
                if (departure.Attributes["pointType"].InnerText == "Gleis")
                {
                    if(departure.Attributes["realtimeTripStatus"] != null)
                    {
                        dep.Status = departure.Attributes["realtimeTripStatus"].InnerText switch
                        {
                            "TRIP_CANCELLED" => Status.Cancelled,
                            "MONITORED" => Status.Running,
                            _ or null => Status.Unknown
                        };
                    }
                    

                    dep.Platform = departure.Attributes["platformName"].InnerText;
                    dep.Countdown = Convert.ToInt32(departure.Attributes["countdown"].InnerText);

                    var departureTime = departure.SelectSingleNode("//itdDateTime");

                    var depDate = departure.SelectSingleNode("//itdDate");
                    var depTime = departure.SelectSingleNode("//itdTime");

                    int year = int.Parse(depDate.Attributes["year"].InnerText);
                    int month = int.Parse(depDate.Attributes["month"].InnerText);
                    int day = int.Parse(depDate.Attributes["day"].InnerText);
                    int hour = int.Parse(depTime.Attributes["hour"].InnerText);
                    int minute = int.Parse(depTime.Attributes["minute"].InnerText);
                    int second = 0;

                    DateTime depTimeDateTime = new(year, month, day, hour, minute, second);

                    dep.DepartureTime = depTimeDateTime;

                    var servingLine = departure.SelectSingleNode("itdServingLine");

                    var servingLineType = servingLine.ChildNodes[0];

                    int delay  = servingLineType.Attributes["delay"] != null ? int.Parse(servingLineType.Attributes["delay"].InnerText) : 0;
                    dep.Delay = delay;
                    dep.Platform = departure.Attributes["platform"].InnerText;
                    dep.Line = servingLine.Attributes["number"].InnerText;
                    dep.Terminus = servingLine.Attributes["direction"].InnerText;

                    string destination = servingLine.Attributes["direction"].InnerText;

                    dep.Terminus = destination.Contains("Hauptbahnhof") ? destination.Replace("Hauptbahnhof", "Hbf") : destination;

                    dep.DepartureStation = servingLine.Attributes["directionFrom"].InnerText;
                    dep.TrainType = servingLineType.Attributes["name"].InnerText switch
                    {
                        "S-Bahn" => TrainType.SBahn,
                        "U-Bahn" => TrainType.UBahn,
                        "Bus" => TrainType.Bus,
                        _ => TrainType.Bus
                    } ;

                    if(depTimeDateTime.AddMinutes(delay) > DateTime.Now)
                    {
                        departureList.Add(dep);
                    }
                }

            }

            vVSTimetable.Departures = departureList;

            return vVSTimetable;
        }

        private static DateTime GetDate(GroupCollection input)
        {
            var stringList = input.Cast<Group>().ToList().ConvertAll(x => x.Value.ToString());
            stringList.RemoveAt(0);
            var intList = stringList.Select(int.Parse).ToList();

            DateTime requestTime = new(intList[0], intList[1], intList[2], intList[3], intList[4], intList[5]);

            return requestTime;
        }
    }
}
