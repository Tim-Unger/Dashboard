using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Dashboard.ConfigClass
{
    class ReadConfig
    {
        public static Config ReadConfigClass()
        {
            Config config = new();
            string configRaw = File.ReadAllText("./config.json");

            var configJson = JsonConvert.DeserializeObject<Config>(configRaw);

            return config;
        }
    }
}
