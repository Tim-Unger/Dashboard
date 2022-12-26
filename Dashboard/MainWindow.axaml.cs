using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.NetworkInformation;
using System;
using Avalonia.Input;
using Dashboard.Nightscout;
using Dashboard.Scheduler;
using Dashboard.VVS;
using static Dashboard.VVS.GetVVS;
using static Dashboard.Nightscout.GetEntries;
using Dashboard.ConfigClass;
using Event = Google.Apis.Calendar.v3.Data.Event;
using System.Collections.Generic;
using Dashboard.Calendar;
using Dashboard.Grocy;
using Avalonia.Media;
using Avalonia.Platform;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

//using System.Windows.Forms;

namespace Dashboard
{
    public partial class MainWindow : Window
    {
        internal VVSTimetable Timetable { get; set; }
        internal Entry LastEntry { get; set; }
        //Can never be null as this is set as the window is loaded
        public static MainWindow Main { get; set; }
        //Can never be null as an exception is thrown when the config is null
        public static Config Config { get; set; }
        public static List<Event>? Events { get; set; }
        public static List<Item>? GrocyItems { get; set; }
        public static List<ShoppingItem>? ShoppingItems { get; set; }

        private static readonly SolidColorBrush DarkGrey = new(Color.FromRgb(40, 40, 40));
        private static readonly SolidColorBrush LightGrey = new(Color.FromRgb(80, 80, 80));
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
            //string vvsData = GetVVSClass();
            //Timetable = ParseVVS.ParseVVSClass(vvsData);
            //RenderVVS.RenderVVSClass(Timetable);

            Config = ReadConfig.ReadConfigClass();

            //Nightscout
            //string nightscoutData = GetEntriesClass();
            //LastEntry = ParseEntries.GetNewestEntry(nightscoutData);
            //RenderEntries.RenderEntryClass(LastEntry);

            //Shifts
            Events  = GetCalendar.GetCalendarClass().Result;
            RenderCalendar.RenderCalendarClass(Events);
            
            //Grocy
            GrocyItems = GetGrocy.GetItems();
            ShoppingItems = GetGrocy.GetShoppingItems();
            RenderShoppingList.RenderShoppingListClass(ShoppingItems);

            //Timers
            Timers.RenderTimers.RenderTimerClass(Config.Timer1Time, Config.Timer2Time);

            SetStartupScreen();
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

        private void Countdown1_Click(object sender, RoutedEventArgs e)
        {
            CountdownButtonsGrid.IsVisible = false;
            CountdownGrid.IsVisible = true;

            int timer1Minutes = Config.Timer1Time[0];
            int timer1Seconds = Config.Timer1Time[1];
            //TODO Hours
            Timers.StartTimer.TimerStart(0, timer1Minutes, timer1Seconds);
        }

        private void Countdown2_Click(object sender, RoutedEventArgs e) 
        {
            CountdownButtonsGrid.IsVisible = false;
            CountdownGrid.IsVisible = true;

            int timer2Minutes = Config.Timer2Time[0];
            int timer2Seconds = Config.Timer2Time[1];
            //TODO
            Timers.StartTimer.TimerStart(0, timer2Minutes, timer2Seconds);
        }

        private void Countdown3_Click(object sender, RoutedEventArgs e)
        {
            CountdownButtonsGrid.IsVisible = false;
            CountdownGrid.IsVisible = true;

            CustomTimer timer = new() { WindowStartupLocation = WindowStartupLocation.CenterOwner };
            timer.Show();
        }
        private void Temperature_MouseLeftButtonDown(object sender, PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }

        private void StationButton_Click(object sender, RoutedEventArgs e) 
        {
            VVSStationViewer.IsVisible = true;
            VVSRouteViewer.IsVisible = false;
            GroceryViewer.IsVisible = false;

            StationButton.Background = DarkGrey;
            RouteButton.Background = LightGrey;
            GroceryButton.Background = LightGrey;
        }

        private void RouteButton_Click(object sender, RoutedEventArgs e)
        {
            VVSStationViewer.IsVisible = false;
            VVSRouteViewer.IsVisible = true;
            GroceryViewer.IsVisible = false;

            StationButton.Background = LightGrey;
            RouteButton.Background = DarkGrey;
            GroceryButton.Background = LightGrey;
        }

        private void GroceryButton_Click(object sender, RoutedEventArgs e)
        {
            VVSStationViewer.IsVisible = false;
            VVSRouteViewer.IsVisible = false;
            GroceryViewer.IsVisible = true;

            StationButton.Background = LightGrey;
            RouteButton.Background = LightGrey;
            VVSRouteViewer.Background = DarkGrey;
        }

        private static void SetStartupScreen()
        {
#if DEBUG
#else
#endif
        }
    }
}
