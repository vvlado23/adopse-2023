using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ADOPSE_2023
{
    public static class FacetedSearch
    {
        public static List<Module> PerformSearch(string priceFilter, string difficultyFilter, int ratingFilter)
        {
            List<Module> filteredModules = new List<Module>();

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT moduleName, price, rating FROM modules WHERE price = @price AND difficulty = @difficulty AND rating = @rating";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@price", priceFilter);
                command.Parameters.AddWithValue("@difficulty", difficultyFilter);
                command.Parameters.AddWithValue("@rating", ratingFilter);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string moduleName = reader["moduleName"].ToString();
                        string price = reader["price"].ToString();
                        int rating = Convert.ToInt32(reader["rating"]);
                        string moduleDesc = reader["moduleDesc"].ToString();
                        int idModules = Convert.ToInt32(reader["idModules"]);

                        Module module = new Module(idModules, moduleName, price, rating, moduleDesc);
                        filteredModules.Add(module);
                    }
                }
            }

            return filteredModules;
        }
    }

}
