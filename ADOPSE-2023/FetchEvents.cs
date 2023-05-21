using ADOPSE_2023;
using MySql.Data.MySqlClient;
public class FetchEvents
{
    public static List<DatabaseEvent> FetchEventsFromDatabase()
    {
        List<DatabaseEvent> events = new List<DatabaseEvent>();
        Dictionary<int, string> lecturerNames = new Dictionary<int, string>();

        using (MySqlConnection connection = DatabaseConnection.GetConnection())
        {
            // Fetch lecturer names
            string lecturerQuery = "SELECT idlecturer, lecturerName FROM lecturer";
            MySqlCommand lecturerCommand = new MySqlCommand(lecturerQuery, connection);

            using (MySqlDataReader lecturerReader = lecturerCommand.ExecuteReader())
            {
                while (lecturerReader.Read())
                {
                    int lecturerId = Convert.ToInt32(lecturerReader["idlecturer"]);
                    string lecturerName = lecturerReader["lecturerName"].ToString();
                    lecturerNames[lecturerId] = lecturerName;
                }
            }

            // Fetch events
            string eventQuery = "SELECT eventId, eventName, idmodule, idlecturer, EventStartsOn,EventsEndsOn FROM event";
            MySqlCommand eventCommand = new MySqlCommand(eventQuery, connection);

            using (MySqlDataReader eventReader = eventCommand.ExecuteReader())
            {
                while (eventReader.Read())
                {
                    string eventId = eventReader["eventId"].ToString();
                    string eventName = eventReader["eventName"].ToString();
                    int moduleId = Convert.ToInt32(eventReader["idmodule"]);
                    int lecturerId = Convert.ToInt32(eventReader["idlecturer"]);
                    DateTime eventStartsOn = Convert.ToDateTime(eventReader["EventStartsOn"]);
                    DateTime eventEndsOn = Convert.ToDateTime(eventReader["EventsEndsOn"]);

                    if (lecturerNames.TryGetValue(lecturerId, out string lecturerName))
                    {
                        DatabaseEvent eventItem = new DatabaseEvent
                        {
                            Summary = eventName,
                            Description = lecturerName,
                            StartDateTime = eventStartsOn
                            , EndDateTime = eventEndsOn
                        };

                        events.Add(eventItem);
                    }
                }
            }
        }

        return events;
    }
}
