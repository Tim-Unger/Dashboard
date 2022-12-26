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

            if (configJson == null)
            {
                throw new Exception();
            }

            //Checks if everything in the Class has a value
            if (
                configJson.GetType().GetProperties().All(x => x != null)
                && configJson.Timer1Time.Length == 2
                && configJson.Timer2Time.Length == 2
            )
            {
                return configJson;
            }

            throw new Exception();
        }
    }
}
