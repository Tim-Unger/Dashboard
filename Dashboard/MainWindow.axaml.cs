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
//using System.Windows.Forms;

namespace Dashboard
{
    public partial class MainWindow : Window
    {
        internal VVSTimetable Timetable { get; set; }
        internal Entry LastEntry { get; set; }
        public static MainWindow Main { get; set; }

        public static Config? Config { get; set; }

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

            Config = ReadConfig.ReadConfigClass();

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

        private void StationButton_Click(object sender, RoutedEventArgs e)
        {
        }

        //TODO Custom Time amount
        private void Countdown1_Click(object sender, RoutedEventArgs e)
        {
            CountdownButtonsGrid.IsVisible = false;
            CountdownGrid.IsVisible = true;

            Timers.StartTimer.TimerStart(0, 10);
        }
        private void Countdown2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Temperature_MouseLeftButtonDown(object sender, PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }
    }
}
