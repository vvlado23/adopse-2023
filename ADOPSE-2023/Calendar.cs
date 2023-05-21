using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ADOPSE_2023
{
    public class Calendar
    {
        private static string[] Scopes = { CalendarService.Scope.Calendar };
        private static string ApplicationName = "ADOPSE";
       private static string CredentialsFilePath = "C:\\Users\\dimit\\OneDrive\\Documents\\GitHub\\adopse-2023\\ADOPSE-2023\\Credentials\\adopse-387323-623c15620f3f.json"; // Replace with the actual path to your credentials file

        public static void AddEventsToCalendar(List<DatabaseEvent> events)
        {
            GoogleCredential credential;

            using (var stream = new FileStream(CredentialsFilePath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });



            List<DatabaseEvent> eventsToRemove = new List<DatabaseEvent>();

            foreach (DatabaseEvent eventItem in events)
            {
                var calendarEvent = new Google.Apis.Calendar.v3.Data.Event
                {
                    Summary = eventItem.Summary,
                    Description = eventItem.Description,
                    Start = new EventDateTime { DateTime = eventItem.StartDateTime },
                    End = new EventDateTime { DateTime = eventItem.EndDateTime }
                };

                var request = service.Events.Insert(calendarEvent, "primary");
                var createdEvent = request.Execute();
                Console.WriteLine("Event created: " + createdEvent.HtmlLink);

                // Add the event to the list of events to be removed
                eventsToRemove.Add(eventItem);
            }

            // Remove the processed events from the original list
            foreach (DatabaseEvent eventToRemove in eventsToRemove)
            {
                events.Remove(eventToRemove);
            }
        }
        }
    }

