using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Layout;
using Color = Avalonia.Media.Color;
using Avalonia.Animation.Animators;
using Avalonia.Interactivity;
using System.Runtime.Intrinsics.X86;

namespace Dashboard
{
    internal class RenderCustomTimer : CustomTimer
    {
        private static readonly SolidColorBrush Grey = new(Color.FromRgb(40, 40, 40));
        private static int CurrentPosition = 5;
        private static Button BackButton { get; set; }
        private static List<int> TimerValue { get; set; } = new() { 0, 0, 0, 0, 0, 0 };

        public static void RenderCustomTimerClass()
        {
            //Grid grid = new();

            RenderFirstRow();

            RenderSecondRow();

            RenderThirdRow();

            RenderFourthRow();

            RenderFifthRow();

            BackButton = (Button)Timer.FifthRow.Children.First(x => (x as Button).Content == "<");
            BackButton.IsEnabled = false;
        }

        private static Button GetButton(string content)
        {
            Button button =
                new()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 40,
                    FontWeight = FontWeight.Bold,
                    //Background = Grey,
                    //Foreground = new SolidColorBrush(Colors.White),
                    Content = content,
                };

            button.Click += Button_Click;

            return button;
        }

        private static void Button_Click(object? sender, RoutedEventArgs e)
        {
            //The Click event is only called from a button which always has a content value, hence it can never be null
#pragma warning disable CS8602, CS8604
            var amount = (sender as Button).Content.ToString();
            BackButton.IsEnabled = CurrentPosition <= 5;

            //remove last value
            if (amount == "<")
            {
                if (CurrentPosition < 5)
                {
                    //Move everything one to the right
                    TimerValue[CurrentPosition + 1] = 0;
                    CurrentPosition += 1;
                    SetTimerText();
                    return;
                }
                return;
            }

            if (CurrentPosition < 0)
            {
                //Do nothing
                return;
            }

            if (amount == "00")
            {
                TimerValue[CurrentPosition] = 0;
                TimerValue[CurrentPosition + 1] = 0;
                CurrentPosition -= 2;
                SetTimerText();
                return;
            }

            int value = int.Parse(amount);
            if (CurrentPosition == 5)
            {
                TimerValue[CurrentPosition] = value;
                CurrentPosition -= 1;
                SetTimerText();
                return;
            }

            TimerValue[CurrentPosition] = TimerValue[CurrentPosition + 1];
            TimerValue[CurrentPosition + 1] = value;
            CurrentPosition -= 1;
            SetTimerText();
            return;
        }

        private static void RenderFirstRow() { }

        private static void RenderSecondRow()
        {
            Button one = GetButton("1");
            Button two = GetButton("2");
            Button three = GetButton("3");

            Timer.SecondRow.Children.Add(one);
            Timer.SecondRow.Children.Add(two);
            Timer.SecondRow.Children.Add(three);

            Grid.SetColumn(one, 0);
            Grid.SetColumn(two, 1);
            Grid.SetColumn(three, 2);
        }

        private static void RenderThirdRow()
        {
            Button four = GetButton("4");
            Button five = GetButton("5");
            Button six = GetButton("6");

            Timer.ThirdRow.Children.Add(four);
            Timer.ThirdRow.Children.Add(five);
            Timer.ThirdRow.Children.Add(six);

            Grid.SetColumn(four, 0);
            Grid.SetColumn(five, 1);
            Grid.SetColumn(six, 2);
        }

        private static void RenderFourthRow()
        {
            Button seven = GetButton("7");
            Button eight = GetButton("8");
            Button nine = GetButton("9");

            Timer.FourthRow.Children.Add(seven);
            Timer.FourthRow.Children.Add(eight);
            Timer.FourthRow.Children.Add(nine);

            Grid.SetColumn(seven, 0);
            Grid.SetColumn(eight, 1);
            Grid.SetColumn(nine, 2);
        }

        private static void RenderFifthRow()
        {
            Button doubleZero = GetButton("00");
            Button zero = GetButton("0");
            Button backSpace = GetButton("<");

            Timer.FifthRow.Children.Add(doubleZero);
            Timer.FifthRow.Children.Add(zero);
            Timer.FifthRow.Children.Add(backSpace);
            Grid.SetColumn(doubleZero, 0);
            Grid.SetColumn(zero, 1);
            Grid.SetColumn(backSpace, 2);
        }

        private static void SetTimerText()
        {
            List<string> values = TimerValue.ConvertAll(x => x.ToString());
            Timer.SecondTwoBlock.Text = values[5];
            Timer.SecondOneBlock.Text = values[4];
            Timer.MinuteTwoBlock.Text = values[3];
            Timer.MinuteOneBlock.Text = values[2];
            Timer.HourTwoBlock.Text = values[1];
            Timer.HourOneBlock.Text = values[0];
            SetColor(CurrentPosition);
        }

        private static readonly SolidColorBrush Blue = new(Colors.LightBlue);

        private static void SetColor(int position)
        {
            Timer.SecondTwoBlock.Foreground = position <= 4 ? Blue : Grey;
            Timer.SecondOneBlock.Foreground = position <= 3 ? Blue : Grey;
            Timer.MinuteTwoBlock.Foreground = position <= 2 ? Blue : Grey;
            Timer.MinuteOneBlock.Foreground = position <= 1 ? Blue : Grey;
            Timer.HourTwoBlock.Foreground = position <= 0 ? Blue : Grey;
            Timer.HourOneBlock.Foreground = position <= -1 ? Blue : Grey;
        }
    }
}
