using ADOPSE_2023;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.IO;

namespace ADOPSE_2023
{
    public class Program
    {
        private static string[] Scopes = { CalendarService.Scope.Calendar };
        private static string ApplicationName = "ADOPSE";
        private static string CredentialsFilePath = "C:\\Users\\dimit\\OneDrive\\Documents\\GitHub\\adopse-2023\\ADOPSE-2023\\Credentials\\adopse-387323-623c15620f3f.json";

        static void Main(string[] args)
        {
            // Faceted search parameters
            string priceFilter = "0";
            string difficultyFilter = "3";
            int ratingFilter = 4;

            // Call the faceted search logic
            List<Module> filteredModules = FacetedSearch.PerformSearch(priceFilter, difficultyFilter, ratingFilter);

            if (filteredModules.Count == 0)
            {
                Console.WriteLine("No modules found matching the search criteria.");
            }
            else
            {
                Console.WriteLine("Apotelesmata");
                // Display the filtered modules
                foreach (Module module in filteredModules)
                {
                    Console.WriteLine($"moduleName: {module.moduleName}");
                    Console.WriteLine($"Price: {module.Price}");
                    Console.WriteLine($"Rating: {module.Rating}");
                    Console.WriteLine();
                }
            }

            // Fetch events from the database
            List<DatabaseEvent> events = FetchEvents.FetchEventsFromDatabase();

            // Call the AddEventsToCalendar method
            Calendar.AddEventsToCalendar(events);
           

            // Wait for user input to keep the console window open
            Console.WriteLine("Events added to calendar. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
