using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.NetworkInformation;
using System;
using Avalonia.Input;
using Dashboard.Nightscout;
using Dashboard.Scheduler;
using Dashboard.VVS;
using System.Xml;
using static Dashboard.VVS.GetVVS;
using static Dashboard.Nightscout.GetEntries;
using Dashboard.ConfigClass;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar;
using Newtonsoft.Json;
using System.IO;
using Google.Apis.Calendar.v3;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Event = Google.Apis.Calendar.v3.Data.Event;
using System.Collections.Generic;
using Dashboard.Calendar;

//using System.Windows.Forms;

namespace Dashboard
{
    public partial class MainWindow : Window
    {
        internal VVSTimetable Timetable { get; set; }
        internal Entry LastEntry { get; set; }
        public static MainWindow Main { get; set; }
        public static Config Config { get; set; }
        public static List<Event> Events { get; set; }

        public MainWindow()
        {
            CheckForInternet();

            InitializeComponent();
#if DEBUG
            this.WindowState = WindowState.Normal;
#else
            //TODO
            this.WindowState = WindowState.FullScreen;

#endif
            Main = this;

            //Clock and timed stuff
            InitializeScheduler.Initialize();

            //VVS
            string vvsData = GetVVSClass();
            Timetable = ParseVVS.ParseVVSClass(vvsData);
            RenderVVS.RenderVVSClass(Timetable);

            Config = ReadConfig.ReadConfigClass();

            //Nightscout
            string nightscoutData = GetEntriesClass();
            LastEntry = ParseEntries.GetNewestEntry(nightscoutData);
            RenderEntries.RenderEntryClass(LastEntry);

            Events  = GetCalendar.GetCalendarClass().Result;
            RenderCalendar.RenderCalendarClass(Events);


        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Main = this;

            //ReadConfigClass();

            //Clock and timed stuff
            InitializeScheduler.Initialize();

            //VVS
            string vvsData = GetVVSClass();
            Timetable = ParseVVS.ParseVVSClass(vvsData);
            RenderVVS.RenderVVSClass(Timetable);

            //Nightscout
            string nightscoutData = GetEntriesClass();
            LastEntry = ParseEntries.GetNewestEntry(nightscoutData);
            RenderEntries.RenderEntryClass(LastEntry);
        }

        private static void CheckForInternet()
        {
            try
            {
                Ping ping = new();
                PingReply pingReply = ping.Send("8.8.8.8");
            }
            catch
            {
                throw new Exception("No Internet");
            }
        }

        private void StationButton_Click(object sender, RoutedEventArgs e) { }

        //TODO Custom Time amount
        private void Countdown1_Click(object sender, RoutedEventArgs e)
        {
            CountdownButtonsGrid.IsVisible = false;
            CountdownGrid.IsVisible = true;

            Timers.StartTimer.TimerStart(0, 10);
        }

        private void Countdown2_Click(object sender, RoutedEventArgs e) { }

        private void Temperature_MouseLeftButtonDown(object sender, PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }
    }
}
