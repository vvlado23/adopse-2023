using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;

namespace ADOPSE_2023.Controllers
{
    public class calendarEvent
    {
        public string? Summary { get; set; }
        public string? Organizer { get; set; }
        public string? Description { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
    }
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

        public List<calendarEvent> GoogleEvents = new List<calendarEvent>();
        //static string[] scopes = { CalendarService.Scope.CalendarReadonly };

        public IActionResult HomePage()
        {
            API();
            ViewBag.EventList = GoogleEvents;
            return View();
        }

        public void API()
        {
            // Authenticate using OAuth 2.0
            UserCredential credential;
            using (var stream = new FileStream("Credential.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { CalendarService.Scope.Calendar },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create the calendar service
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Ogma"
            });

            // Query the calendar events
            var events = service.Events.List("primary").Execute().Items;

            // Display the calendar events in your web app
            foreach (var evt in events)
            {
                // Display the event details (title, start time, end time, etc.)
                var calendarevt = new calendarEvent();
                calendarevt.Organizer = evt.Organizer.Email;
                calendarevt.Summary = evt.Summary;
                calendarevt.StartTime = evt.Start.DateTimeRaw.ToString();
                calendarevt.EndTime = evt.End.DateTimeRaw.ToString();
                calendarevt.Description = evt.Description;
                GoogleEvents.Add(calendarevt);
            }

        }
    }
}
