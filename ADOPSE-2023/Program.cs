using ADOPSE_2023;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using Lucene.Net.Store;
using ADOPSE_2023;
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
app.Run();
