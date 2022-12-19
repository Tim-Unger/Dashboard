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
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Dashboard.Scheduler
{
   
    internal class InitializeScheduler
    {
        private static DispatcherTimer ClockTimer = new();
        private static DispatcherTimer WeatherTimer = new();

        public static void Initialize()
        {
            JobManager.Initialize();

            ClockTimer.Tick += ClockTimer_Elapsed;
            ClockTimer.Interval = new TimeSpan(0,0,1); //every second
            ClockTimer.Start();

            UpdateWeather.Weather();
            WeatherTimer.Tick += WeatherTimer_Elapsed;
            WeatherTimer.Interval = new TimeSpan(0, 2, 0); // every two minutes
            WeatherTimer.Start();
        }

        private static void ClockTimer_Elapsed(object? sender, EventArgs e)
        {
            UpdateClock.Clock();
        }

        private static void WeatherTimer_Elapsed(object? sender, EventArgs e)
        {
            UpdateWeather.Weather();
        }
    }
}
