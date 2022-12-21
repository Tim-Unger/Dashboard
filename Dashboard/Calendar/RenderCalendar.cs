using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event = Google.Apis.Calendar.v3.Data.Event;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using System.Runtime.CompilerServices;
using System.Net.WebSockets;
using EventDateTime = Google.Apis.Calendar.v3.Data.EventDateTime;
using System.Threading;

namespace Dashboard.Calendar
{
    public enum ShiftType
    {
        Früh,
        Spät,
        Urlaub,
        Frei
    }

    internal class RenderCalendar : MainWindow
    {
        public static void RenderCalendarClass(List<Event> events)
        {
            //Shift type and weekday
            List<(ShiftType?, string)> nextDays = new();

            //Gets the names for today and the next four days
            for (int i = 0; i <= 4; i++)
            {
                var addDays = DateTime.Now.AddDays(i);
                string dayName = addDays.DayOfWeek.ToString();
                nextDays.Add((GetShiftType(addDays, i), TranslateDayOfWeek(dayName)));
            }

            for (int i = 0; i < nextDays.Count; i++)
            {
                TextBlock weekDay =
                new()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 25,
                    FontWeight = FontWeight.Bold,
                    Foreground = new SolidColorBrush(Colors.Black),
                    Text = nextDays[i].Item2,
                };

                Main.NextShiftsGrid.Children.Add(weekDay);
                Grid.SetRow(weekDay, i);
                Grid.SetColumn(weekDay, 0);

                TextBlock shiftType = new()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 25,
                    FontWeight = FontWeight.Bold,
                    Text = nextDays[i].Item1.ToString(),
                };
                shiftType.Foreground = nextDays[i].Item1 switch
                {
                    null => new SolidColorBrush(Colors.White),
                    ShiftType.Früh => new SolidColorBrush(Colors.LightBlue),
                    ShiftType.Spät => new SolidColorBrush(Colors.LightGreen),
                    ShiftType.Urlaub => new SolidColorBrush(Colors.Red),
                    _ => throw new Exception()
                };

                Main.NextShiftsGrid.Children.Add(shiftType);
                Grid.SetRow(shiftType, i);
                Grid.SetColumn(shiftType, 1);
            }
        }

        private static string TranslateDayOfWeek(string day) =>
            day switch
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

        private static ShiftType? GetShiftType(DateTime date, int index)
        {
            var singleEvent = Events.FirstOrDefault(x => x.Start.DateTime.Value.ToString("ddMM") == date.ToString("ddMM"));

            if(singleEvent is null)
            {
                return null;
            }

            var summary = singleEvent.Summary;

            return summary switch
            {
                string when summary.Contains("Früh") => ShiftType.Früh,
                string when summary.Contains("Spät") => ShiftType.Spät,
                string when summary.Contains("Urlaub") => ShiftType.Urlaub,
                _ => throw new Exception(),

            };
        }
    }
}
