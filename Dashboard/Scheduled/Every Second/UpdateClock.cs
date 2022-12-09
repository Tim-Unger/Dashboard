using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Scheduler
{
    internal class UpdateClock : MainWindow
    {
        public static void Clock()
        {
            var now = DateTime.Now;

            Main.Hour.Text = now.Hour.ToString();
            Main.Minute.Text = now.Minute.ToString();
            Main.Second.Text = now.Second.ToString();

            Main.Weekday.Text = Wochentag(now.DayOfWeek.ToString());

            var utcNow = DateTime.UtcNow;

            Main.ZuluTime.Text = utcNow.ToString("t") + "Z";
        }

        private static string Wochentag(string day) => day switch
        {
            "Monday" => "Montag",
            "Tuesday" => "Dienstag",
            "Wednesday" => "Mittwoch",
            "Thursday" => "Donnerstag",
            "Friday" => "Freitag",
            "Saturday" => "Samstag",
            "Sunday" => "Sonntag",
            _ => throw new Exception("Komischer Wochentag")
        };
    }
}
