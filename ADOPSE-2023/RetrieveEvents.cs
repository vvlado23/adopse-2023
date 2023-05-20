using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;

namespace ADOPSE_2023
{
    public class RetrieveEvents
    {
        public void getEvents()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT EventName, Eventdetails, EventStartsOn, EventsEndsOn FROM event JOIN modules ON modules.idModules = event.idmodule JOIN lecturer ON lecturer.idLecturer = event.idlecturer";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string col1 = rd["EventName"].ToString();
                string col2 = rd["Eventdetails"].ToString();
                string col3 = rd["EventStartsOn"].ToString();
                string col4 = rd["EventsEndsOn"].ToString();
                Console.WriteLine("Event name: ", col1);
                Console.WriteLine("Event details: ", col2);
                Console.WriteLine("Event starts on: ", col3);
                Console.WriteLine("Event ends on: ", col4);
                Console.WriteLine();
            }
            rd.Close();
            conn.Close();
        }
    }
}
