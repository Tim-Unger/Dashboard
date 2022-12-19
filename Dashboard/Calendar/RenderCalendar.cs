using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event = Google.Apis.Calendar.v3.Data.Event;
using System.Collections.Generic;

namespace Dashboard.Calendar
{
    internal class RenderCalendar
    {
        public static void RenderCalendarClass(List<Event> events)
        {
            List < (DateTime, string)> nextDays = new();
            
            //Gets the names for today and the next four days
            for(int i = 0; i <= 4; i++)
            {
                string dayName = DateTime.Now.AddDays(i).DayOfWeek.ToString();
                nextDays.Add((DateTime.Now.AddDays(i), TranslateDayOfWeek(dayName)));
            }

            foreach(var calEvent in events)
            {
                DateTime dateTime = calEvent.Start.DateTime ?? throw new Exception();
                if(calEvent.Start.DateTime)
            }
        }

        private static string TranslateDayOfWeek(string day) => day switch
        {
            "Monday" => "Montag",
            "Tuesday" => "Dienstag",
            "Wednesday" => "Mittwoch",
            "Thursday" => "Donnerstag",
            "Friday" => "Freitag",
            "Saturday" => "Samstag",
            "Sunday" => "Sonntag",
            _ => throw new Exception("Weird day")
        };
    }
}
