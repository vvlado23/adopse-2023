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



//string connectionString = "server=it154484.mysql.database.azure.com;database=it185158;uid=it185158;password=Ogma123!;";

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
