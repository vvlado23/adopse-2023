using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Lucene.Net.Store;
using ADOPSE_2023;

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

/*UserAuth register = new UserAuth();

register.RegisterUser("test@email", "test", "test");

app.Run();
*/

UserAuth login = new UserAuth();

login.LoginUser("test", "test1");



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
