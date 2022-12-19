using Dashboard.Scheduled.Every_Minute;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Windows.Documents;

namespace Dashboard.Scheduler
{
    internal class UpdateWeather : MainWindow
    {
        public static readonly long LocationId = 102875392;

        public static void Weather()
        {
            List<Forecast> forecasts = GetForecast();
            RenderForecast(forecasts);
        }

        private static void RenderForecast(List<Forecast> forecasts)
        {
            Main.Temperature.Text = ConcatTemperature(forecasts, 0);

            Main.TempOneHour.Text = ConcatTemperature(forecasts, 1);
            Main.TimeOneHour.Text = forecasts[1].Time.ToString("HH:mm");

            Main.TempTwoHour.Text = ConcatTemperature(forecasts, 2);
            Main.TimeTwoHour.Text = forecasts[2].Time.ToString("HH:mm");

            Main.TempThreeHour.Text = ConcatTemperature(forecasts, 3);
            Main.TimeThreeHour.Text = forecasts[3].Time.ToString("HH:mm");
        }

        private static string ConcatTemperature(List<Forecast> forecasts, int index)
        {
            return forecasts[index].Temperature.ToString() + "°C";
        }

        private static List<Forecast> GetForecast()
        {
            var client = new RestClient(
                $"https://foreca-weather.p.rapidapi.com/forecast/hourly/{LocationId}?alt=0&tempunit=C&windunit=KMH&tz=Europe%2FBerlin&periods=5&dataset=standard&history=0"
            );
            var request = new RestRequest();
            string key = File.ReadAllText("./.key");
            request.AddHeader("X-RapidAPI-Key", key);
            request.AddHeader("X-RapidAPI-Host", "foreca-weather.p.rapidapi.com");

            var result = client.Execute(request);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var forecast = JsonConvert.DeserializeObject<Rootobject>(result.Content).Forecast;
                return forecast.ToList();
            }

            throw new Exception("Weather Fetching Error");
        }
    }
}
