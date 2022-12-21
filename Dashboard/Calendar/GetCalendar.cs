using Dashboard.ConfigClass;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dashboard;
using static Dashboard.MainWindow;
using System.ComponentModel;
using Event = Google.Apis.Calendar.v3.Data.Event;
using System.Collections.Generic;

namespace Dashboard.Calendar
{
    internal class GetCalendar
    {
        public static async Task<List<Event>> GetCalendarClass()
        {
            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets { ClientId = MainWindow.Config.ClientId, ClientSecret = MainWindow.Config.ClientKey },
                new[] { CalendarService.Scope.CalendarEventsReadonly },
                "user",
                CancellationToken.None,
                new FileDataStore("Calendar.Events")
            );

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Dashboard"
            });

            var calendarsRaw = await service.Events.List("timderkuerbis@gmail.com").ExecuteAsync().ConfigureAwait(false);

            return calendarsRaw.Items.ToList().Where(x => x.Start.DateTime.HasValue && x.Start.DateTime.Value.Day >= DateTime.Now.Day && new[] { "Früh", "Spät" }.Any(y => x.Summary.Contains(y))).Take(5).ToList();
        }
    }
}
