using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Nightscout
{
    internal class GetEntries
    {
        public static string GetEntriesClass()
        {
           
            WebClient client = new WebClient();
            string downloadedString = client.DownloadString("http://cgm.tim-u.me/api/v1/entries.json");


            return downloadedString;
        }

        
    }
}
