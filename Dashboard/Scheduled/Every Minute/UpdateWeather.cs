﻿using Dashboard.Scheduled.Every_Minute;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Dashboard.Scheduler
{
    internal class UpdateWeather : MainWindow
    {
        public static long LocationId { get; } = 102875392;

        public static void Weather()
        {
            var client = new RestClient($"https://foreca-weather.p.rapidapi.com/current/{LocationId}?alt=0&tempunit=C&windunit=KMH&tz=Europe%2FBerlin&lang=de");
            var request = new RestRequest();
            string key = File.ReadAllText("./.key");
            request.AddHeader("X-RapidAPI-Key", key);
            request.AddHeader("X-RapidAPI-Host", "foreca-weather.p.rapidapi.com");

            var result = client.Execute(request);

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Rootobject root = JsonConvert.DeserializeObject<Rootobject>(result.Content);
                Current weather = root.current;

                Main.Temperature.Text = weather.Temperature.ToString() + "°C"; 
                return;
            }
            throw new Exception("Weather Fetching Error");
        }
    }
}
