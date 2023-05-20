using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;

namespace ADOPSE_2023
{
    public class RetrieveEvents
    {
        public void getEvents()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM event";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine(rd.GetString(0));
            }
            rd.Close();
            conn.Close();
        }
    }
}
