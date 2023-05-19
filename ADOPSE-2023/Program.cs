using ADOPSE_2023;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

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
string priceFilter = "free";
string difficultyFilter = "beginner";
int ratingFilter = 4;

// Call the faceted search logic
List<Module> filteredModules = FacetedSearch.PerformSearch(priceFilter, difficultyFilter, ratingFilter);

// Display the filtered modules
foreach (Module module in filteredModules)
{
    Console.WriteLine($"Module ID: {module.Id}");
    Console.WriteLine($"Module Name: {module.Name}");
    Console.WriteLine($"Price: {module.Price}");
    Console.WriteLine($"Difficulty: {module.Difficulty}");
    Console.WriteLine($"Rating: {module.Rating}");
    Console.WriteLine();
}

app.Run();
