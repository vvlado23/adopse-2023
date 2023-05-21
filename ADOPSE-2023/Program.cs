using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Lucene.Net.Store;
using ADOPSE_2023;
using System.Data;

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




/* //try fetch
FetchData dataFetcher = new FetchData();
DataTable dataTable = dataFetcher.FetchDataFromTable();

// Process the fetched data
foreach (DataRow row in dataTable.Rows)
{
    int idCategory = (int)row["idCategory"];
    int idModule = (int)row["idModule"];
    string categoryName = row["CategoryName"].ToString();

    // Display the fetched data on the console
    Console.WriteLine($"Category ID: {idCategory}, Module ID: {idModule}, Category Name: {categoryName}");
}*/



// Faceted search parameters
string priceFilter = "0";
string difficultyFilter = "3";
int ratingFilter = 3;

// Call the faceted search logic
List<Module> filteredModules = FacetedSearch.PerformSearch(priceFilter, difficultyFilter, ratingFilter,15374);

Console.WriteLine("apotelesmata:");
// Display the filtered modules
foreach (Module module in filteredModules)
{
    Console.WriteLine($"Module ID: {module.moduleName}");
    Console.WriteLine($"Module Name: {module.idModules}");
    Console.WriteLine($"Price: {module.Price}");
    Console.WriteLine($"Rating: {module.Rating}");
    Console.WriteLine($"Category: {module.categoryName}");
    Console.WriteLine();
}

app.Run();




