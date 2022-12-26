using Avalonia.Controls;
using Avalonia.Interactivity;
using Dashboard.Timers;

namespace Dashboard
{
    public partial class CustomTimer : Window
    {
        public static CustomTimer Timer { get; set; }
        public CustomTimer()
        {
            InitializeComponent();
            Timer = this;
            RenderCustomTimer.RenderCustomTimerClass();
        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            int hours = int.Parse(HourOneBlock.Text + HourTwoBlock.Text);
            int minutes = int.Parse(MinuteOneBlock.Text + MinuteTwoBlock.Text);
            int seconds = int.Parse(SecondOneBlock.Text + SecondTwoBlock.Text);

            Timers.StartTimer.TimerStart(hours, minutes, seconds);
            Timer.Close();
        }
    }
}
