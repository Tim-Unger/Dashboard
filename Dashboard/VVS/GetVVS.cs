using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.VVS
{
    class GetVVS
    {
        public static string GetVVSClass()
        {
            WebClient client = new WebClient();
            try
            {
                string downloadedString = client.DownloadString("https://efastatic.vvs.de/OpenVVSDay/XML_DM_REQUEST?laguage=de&typeInfo_dm=stopID&nameInfo_dm=Ludwigsburg&deleteAssignedStops_dm=1&useRealtime=1&mode=direct");
                return downloadedString;
            }
            catch
            {
                throw new Exception("VVS unavailable");
            }
        }
    }
}
