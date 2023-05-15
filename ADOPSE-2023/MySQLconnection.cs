

//old!!!!
/*using MySql.Data.MySqlClient;

public static class MySqlconnection
{
    public static MySqlConnection GetConnection()
    {
        string connectionString = "server=dblabs.iee.ihu.gr;database=3306;uid=it185158;password=Ogma123!;";
        return new MySqlConnection(connectionString);
    }

    public static MySqlCommand GetCommand(string query)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        return new MySqlCommand(query, connection);
    }
}*/
//NEW!!!!

using MySql.Data.MySqlClient;
using System;
public static class MySqlconnection
{
    public static MySqlConnection GetConnection()
    {
        string connectionString = "server=dblabs.iee.ihu.gr;database=it185158;uid=it185158;password=Ogma123!;";
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