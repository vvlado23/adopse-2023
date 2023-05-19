using ADOPSE_2023.Models;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ADOPSE_2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "ADOPSE-2023";

        public IActionResult HomePage()
        {
            UserCredential credential;

            using (var stream = new FileStream("Credential.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters for the request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // Execute the request and retrieve the events.
            Events events = request.Execute();

            List<GoogleEvent> upcomingEvents = new List<GoogleEvent>();

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }

                    GoogleEvent googleEvent = new GoogleEvent
                    {
                        Summary = eventItem.Summary,
                        Description = eventItem.Description,
                        Organizer = eventItem.Organizer.DisplayName,
                        Start = eventItem.Start.DateTime,
                        End = eventItem.End.DateTime
                    };

                    upcomingEvents.Add(googleEvent);
                }
            }
            return View(upcomingEvents);
        }

        public class GoogleEvent
        {
            public string Summary { get; set; }
            public string Description { get; set; }
            public string Organizer { get; set; }
            public DateTime? Start { get; set; }
            public DateTime? End { get; set; }
        }
    }
}