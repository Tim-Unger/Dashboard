using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;
using Avalonia.Media;

namespace Dashboard.Nightscout
{
    internal class RenderEntries : MainWindow
    {
        public static void RenderEntryClass(Entry entry)
        {
            if(entry.Value < 70 || entry.Value > 250)
            {
                Main.BgValue.Foreground = new SolidColorBrush(Colors.Red);
            }

            Main.BgValue.Text = entry.Value.ToString();

            Main.BgDelta.Text = "Delta: " + entry.Delta;

            int minutesAgo = (DateTime.Now - entry.Date).Minutes;
            Main.BgTime.Text = minutesAgo + " Minutes ago";
        }
    }
}
