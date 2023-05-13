using MySql.Data.MySqlClient;

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
}