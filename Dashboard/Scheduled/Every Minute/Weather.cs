using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Scheduled.Every_Minute
{
    //internal class Current
    //{
    //    public string Time { get; set; }
    //    public string Symbol { get; set; }
    //    public string SymbolPhrase { get; set; }
    //    public int Temperature { get; set; }
    //    public int FeelsLikeTemp { get; set; }
    //    public int RelHumidity { get; set; }
    //    public int DewPoint { get; set; }
    //    public int WindSpeed { get; set; }
    //    public int WindDir { get; set; }
    //    public string WindDirString { get; set; }
    //    public int WindGust { get; set; }
    //    public int PrecipProb { get; set; }
    //    public int PrecipRate { get; set; }
    //    public int ThunderProb { get; set; }
    //    public int UVIndex { get; set; }
    //    public string Pressure { get; set; }
    //    public int Visibility { get; set; }

    //}

    public class Rootobject
    {
        public Forecast[] Forecast { get; set; }
    }

    public class Forecast
    {
        public DateTime Time { get; set; }
        public string Symbol { get; set; }
        public double Temperature { get; set; }
        public double FeelsLikeTemp { get; set; }
        public double WindSpeed { get; set; }
        public double WindGust { get; set; }
        public double WindDir { get; set; }
        public string WindDirString { get; set; }
        public double PrecipProb { get; set; }
        public double PrecipAccum { get; set; }
    }


    //public class Rootobject
    //{
    //    public Current Current { get; set; }
    //}

    //public class Current
    //{
    //    public string Time { get; set; }
    //    public string Symbol { get; set; }
    //    //public string symbolPhrase { get; set; }
    //    public float Temperature { get; set; }
    //    public float FeelsLikeTemp { get; set; }
    //    //public float RelHumidity { get; set; }
    //    //public float DewPoint { get; set; }
    //    public float WindSpeed { get; set; }
    //    public float WindDir { get; set; }
    //    public string WindDirString { get; set; }
    //    public float WindGust { get; set; }
    //    public float PrecipProb { get; set; }
    //    public float PrecipAccum { get; set; }
    //    //public int Cloudiness { get; set; }
    //    //public float ThunderProb { get; set; }
    //    //public float UvIndex { get; set; }
    //    //public float Pressure { get; set; }
    //    //public int Visibility { get; set; }
    //}

}
