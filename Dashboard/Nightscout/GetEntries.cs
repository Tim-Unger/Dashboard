using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Nightscout
{
    internal class GetEntries
    {
        public static async Task<string> GetEntriesClass()
        {
           
            //WebClient client = new WebClient();
            HttpClient client = new();
            string downloadedString = await client.GetStringAsync("http://cgm.tim-u.me/api/v1/entries.json").ConfigureAwait(false);


            return downloadedString;
        }

        
    }
}
