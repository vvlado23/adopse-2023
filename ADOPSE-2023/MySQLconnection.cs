using MySql.Data.MySqlClient;

public static class MySqlconnection
{
    public static MySqlConnection GetConnection()
    {
        string connectionString = "server=localhost;database=mydatabase;uid=myusername;password=mypassword;";
        return new MySqlConnection(connectionString);
    }

    public static MySqlCommand GetCommand(string query)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        return new MySqlCommand(query, connection);
    }
}