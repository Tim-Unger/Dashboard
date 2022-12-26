using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Timers
{
    internal class RenderTimers : MainWindow
    {
        public static void RenderTimerClass(int[] timer1Value, int[] timer2Value)
        {
            //Adds a zero if the value is lower than 10
            string timer1Minutes =
                timer1Value[0] > 9 ? timer1Value[0].ToString() : "0" + timer1Value[0];
            string timer1Seconds =
                timer1Value[1] > 9 ? timer1Value[1].ToString() : "0" + timer1Value[1];

            string timer2Minutes =
                timer2Value[0] > 9 ? timer2Value[0].ToString() : "0" + timer2Value[0];
            string timer2Seconds =
                timer2Value[1] > 9 ? timer2Value[1].ToString() : "0" + timer2Value[1];

            Main.Countdown1.Content = timer1Minutes + ":" + timer1Seconds;
            Main.Countdown2.Content = timer2Minutes + ":" + timer2Seconds;
        }
    }
}
