using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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

            string hour = now.Hour.ToString();
            Main.Hour.Text = hour.Length == 2 ? hour : "0" + hour;

            string minute = now.Minute.ToString();
            Main.Minute.Text = minute.Length == 2 ? minute : "0" + minute;

            string second = now.Second.ToString();
            Main.Second.Text = second.Length == 2 ? second : "0" + second;

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
