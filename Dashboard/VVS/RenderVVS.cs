using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows;
//using System.Windows.Media;
using Avalonia.Controls;
using Avalonia.Media;
//using System.DirectoryServices.ActiveDirectory;

namespace Dashboard.VVS
{
    internal class RenderVVS : MainWindow
    {
        public static void RenderVVSClass(VVSTimetable timetable)
        {
            foreach (var dep in timetable.Departures)
            {
                if (Main.VVSStationViewer.Children.Count <= 7)
                {
                    Grid grid = RenderColumns();

                    TextBlock line = GetTextBlock(dep.Line);
                    grid.Children.Add(line);
                    Grid.SetColumn(line, 0);

                    TextBlock destination = GetTextBlock(dep.Terminus);
                    grid.Children.Add(destination);
                    Grid.SetColumn(destination, 1);

                    string depTimeAsTime = dep.DepartureTime.Hour + ":" + dep.DepartureTime.Minute;
                    string depTimeAsCountdown = dep.Countdown.ToString() + "'";
                    string depTimeString = DateTime.Now.AddMinutes(20) < dep.DepartureTime ? depTimeAsTime : depTimeAsCountdown;
                    TextBlock depTime = GetTextBlock(depTimeString);
                    grid.Children.Add(depTime);
                    Grid.SetColumn(depTime, 2);

                    int delayAmount = dep.Delay;
                    if (delayAmount > 0)
                    {
                        TextBlock delay = GetTextBlock("+" + dep.Delay.ToString());
                        if (delayAmount > 5)
                        {
                            delay.Foreground = new SolidColorBrush(Colors.Red);
                        }

                        grid.Children.Add(delay);
                        Grid.SetColumn(delay, 3);
                    }

                    TextBlock platform = GetTextBlock("Gleis " + dep.Platform);
                    grid.Children.Add(platform);
                    Grid.SetColumn(platform, 4);

                    Main.VVSStationViewer.Children.Add(grid);
                    continue;
                }
                break;
            }

            string updateTime = "Updated: " + timetable.RequestTime.Hour + ":" + timetable.RequestTime.Minute + ":" + timetable.RequestTime.Second;
            Main.UpdateTime.Text = updateTime;
        }

        private static Grid RenderColumns()
        {
            Grid grid = new();

            ColumnDefinition line = new()
            {
                Width = new GridLength(1, GridUnitType.Star)
            };

            ColumnDefinition destination = new()
            {
                Width = new GridLength(3, GridUnitType.Star)
            };

            ColumnDefinition deptime = new()
            {
                Width = new GridLength(0.5, GridUnitType.Star)
            };

            ColumnDefinition delay = new()
            {
                Width = new GridLength(1, GridUnitType.Star)

            };

            ColumnDefinition platform = new()
            {
                Width = new GridLength(1, GridUnitType.Star)
            };

            grid.ColumnDefinitions.Add(line);
            grid.ColumnDefinitions.Add(destination);
            grid.ColumnDefinitions.Add(deptime);
            grid.ColumnDefinitions.Add(delay);
            grid.ColumnDefinitions.Add(platform);

            return grid;
        }

        private static TextBlock GetTextBlock(string text)
        {
            TextBlock textBlock = new()
            {
                FontSize = 30,
                FontWeight = FontWeight.Bold,
                Text = text,
                TextTrimming = TextTrimming.CharacterEllipsis
            };
            return textBlock;
        }
    }
}
