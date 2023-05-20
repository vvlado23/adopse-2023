using ADOPSE_2023;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
//Console
using System;

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
app.Run();
