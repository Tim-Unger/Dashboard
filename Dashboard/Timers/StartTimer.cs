using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Avalonia.Threading;
using Avalonia.Media;
using Plugin.SimpleAudioPlayer;
using System.Net.Http.Headers;
using Vortice.Multimedia;
using System.IO;

namespace Dashboard.Timers
{
    class StartTimer : MainWindow
    {
        public Stopwatch Stopwatch = new();
        public static DispatcherTimer Timer = new();
        
        public static int Duration;

        public static void TimerStart(int minutes, int seconds)
        {
            Duration =  minutes * 60 + seconds;

            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Elapsed;
            Timer.Interval = new TimeSpan(0,0,1);
            Timer.Start();

            string secondsLeft = seconds > 9 ? seconds.ToString() : "0" + seconds.ToString();
            string minutesLeft = minutes > 9 ? seconds.ToString() : "0" + seconds.ToString();
            Main.Countdown.Text = minutesLeft + ":" + secondsLeft;
        }

        private static void Timer_Elapsed(object? sender, EventArgs e)
        {
            if (Duration == 0)
            {
                var engine = SharpAudio.AudioEngine.CreateDefault();
                var stream = new SharpAudio.Codec.SoundStream(File.OpenRead("/TimerSound.wav"), engine);
                Timer.Stop();

                //TODO
                stream.Volume = 1.0f;
                stream.Play();
                //TODO Stop Player click
                return;
            }

            Duration--;
            TimeSpan timeLeft = TimeSpan.FromSeconds(Duration);

            string secondsLeft = timeLeft.Seconds > 9 ? timeLeft.Seconds.ToString() : "0" + timeLeft.Seconds.ToString();
            string minutesLeft = timeLeft.Minutes > 9 ? timeLeft.Minutes.ToString() : "0" + timeLeft.Minutes.ToString();
            Main.Countdown.Text = minutesLeft + ":" + secondsLeft;
        }
    }
}
