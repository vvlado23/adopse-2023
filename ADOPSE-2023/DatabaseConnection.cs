using MySql.Data.MySqlClient;
using System;

namespace ADOPSE_2023
{
    public static class DatabaseConnection
    {
        public static MySqlConnection GetConnection()
        {
            //string connectionString = "server=dblabs.iee.ihu.gr;database=it185158;uid=it185158;password=Ogma123!;";
            string connectionString = "server=it154484.mysql.database.azure.com;database=it185158;uid=it185158;password=Ogma123!;";
            var connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection Success!"); // print the message on the console
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
            }
            return connection;
        }
    }
}