using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Lucene.Net.Store;

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

<<<<<<< Updated upstream
app.Run();
=======
// ...

// Create an instance of the Search class
Search search = new Search();

Search.IndexDocuments();

// Call the SearchDocuments method
var searchTerm = "οικ";
List<Module> searchResults = Search.SearchDocuments(searchTerm, Search.indexDirectory);

// Display the search results
foreach (Module module in searchResults)
{
    Console.WriteLine($"Module ID: {module.moduleName}");
    Console.WriteLine($"Module Name: {module.idModules}");
    Console.WriteLine($"Price: {module.Price}");
    Console.WriteLine($"Rating: {module.Rating}");
    Console.WriteLine();
}
app.Run();

/*
// Faceted search parameters
string priceFilter = "free";
string difficultyFilter = "beginner";
int ratingFilter = 4;

// Call the faceted search logic
List<Module> filteredModules = FacetedSearch.PerformSearch(priceFilter, difficultyFilter, ratingFilter);

// Display the filtered modules
foreach (Module module in filteredModules)
{
    Console.WriteLine($"Module ID: {module.moduleName}");
    Console.WriteLine($"Module Name: {module.idModules}");
    Console.WriteLine($"Price: {module.Price}");
    Console.WriteLine($"Rating: {module.Rating}");
    Console.WriteLine();
}
*/
>>>>>>> Stashed changes
