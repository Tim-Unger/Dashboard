using Dashboard.Scheduler;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Timers;
using Avalonia.Threading;

namespace Dashboard.Scheduler
{
   
    internal class InitializeScheduler
    {
        private static DispatcherTimer ClockTimer;

        public static void Initialize()
        {
            //JobManager.Initialize();
            UpdateWeather.Weather();
            ClockTimer = new DispatcherTimer();
            ClockTimer.Tick += ClockTimer_Elapsed;
            ClockTimer.Interval = new TimeSpan(0,0,1); // in miliseconds
            ClockTimer.Start();

            //JobManager.AddJob(
            //    ()=> UpdateClock.Clock(),
            //    task => task.ToRunEvery(10).Seconds());
        }

        private static void ClockTimer_Elapsed(object? sender, EventArgs e)
        {
            UpdateClock.Clock();
        }
    }
}
