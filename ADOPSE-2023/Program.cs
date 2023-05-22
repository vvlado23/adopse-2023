using ADOPSE_2023;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using Lucene.Net.Store;
using ADOPSE_2023.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}");

app.MapRazorPages();

// Faceted search parameters
string priceFilter = "80";
string difficultyFilter = "3";
int ratingFilter = 3;

// Call the faceted search logic
List<Module> filteredModules = FacetedSearch.PerformSearch(categoryFilter:15374);
//List<Module> filteredModules = FacetedSearch.PerformSearchAll(priceFilter, difficultyFilter, ratingFilter, 15374);





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
        Console.WriteLine($"Difficulty: {module.Difficulty}");
        Console.WriteLine();
                }
            }

            // Fetch events from the database
            List<DatabaseEvent> events = FetchEvents.FetchEventsFromDatabase();

            if (events.Count == 0)
            {
                Console.WriteLine("No events found.");
            }
            else
            {
                Console.WriteLine("Events:");
                foreach (DatabaseEvent ev in events)
                {
                    Console.WriteLine($"Summary: {ev.Summary}");
                    Console.WriteLine($"Description: {ev.Description}");
                    Console.WriteLine($"Starts on: {ev.StartDateTime}");
                    Console.WriteLine($"Ends on: {ev.EndDateTime}");
                    Console.WriteLine();
                }

                // Call the AddEventsToCalendar method
                //Calendar.AddEventsToCalendar(events);


                // Wait for user input to keep the console window open
                Console.WriteLine("Events added to calendar. Press any key to exit.");
                //Console.ReadKey();
            }


        


UserAuth register = new UserAuth();
register.RegisterUser("test@email", "test", "test");
UserAuth login = new UserAuth();
login.LoginUser("test", "test1");
app.Run();

