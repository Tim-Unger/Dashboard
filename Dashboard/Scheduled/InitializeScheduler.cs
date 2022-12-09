using Dashboard.Scheduler;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard.Scheduler
{
   
    internal class InitializeScheduler
    {
        private static Timer ClockTimer;

        public static void Initialize()
        {
            //JobManager.Initialize();
            ClockTimer = new Timer();
            ClockTimer.Tick += new EventHandler(timer1_Tick);
            ClockTimer.Interval = 500; // in miliseconds
            ClockTimer.Start();

            //JobManager.AddJob(
            //    ()=> UpdateClock.Clock(),
            //    task => task.ToRunEvery(10).Seconds());
        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            UpdateClock.Clock();
            UpdateWeather.Weather();
        }
    }
}
