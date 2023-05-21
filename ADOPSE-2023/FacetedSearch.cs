using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ADOPSE_2023
{
    public static class FacetedSearch
    {
        public static List<Module> PerformSearchCategories(string priceFilter, string difficultyFilter, int ratingFilter, int categoryFilter)
        {
            List<Module> filteredModules = new List<Module>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT idModules,m.moduleName, m.Difficulty, m.Price, m.Rating, m.moduleDesc, c.CategoryName " +
               "FROM modules AS m " +
               "JOIN moduleCategories AS mc ON m.idModules = mc.idModule " +
               "JOIN categories AS c ON mc.idCategory = c.idCategory " +
               "WHERE m.price = @price AND m.difficulty = @difficulty AND m.rating = @rating AND mc.idCategory = @category";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@price", priceFilter);
                command.Parameters.AddWithValue("@difficulty", difficultyFilter);
                command.Parameters.AddWithValue("@rating", ratingFilter);
                command.Parameters.AddWithValue("@category", categoryFilter);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string moduleName = reader["moduleName"].ToString();
                        string price = reader["price"].ToString();
                        int rating = Convert.ToInt32(reader["rating"]);
                        int difficulty = Convert.ToInt32(reader["rating"]);
                        string moduleDesc = reader["moduleDesc"].ToString();
                        int idModules = Convert.ToInt32(reader["idModules"]);
                        string categoryName = reader["CategoryName"].ToString();

                        Module module = new Module(idModules, moduleName, price, rating, moduleDesc,categoryName);
                        filteredModules.Add(module);
                    }
                }
            }

            return filteredModules;
        }
    }

}