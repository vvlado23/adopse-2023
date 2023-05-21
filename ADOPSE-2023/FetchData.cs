using MySql.Data.MySqlClient;
using System.Data;

namespace ADOPSE_2023
{
    
    public class FetchData
    {
        string connectionString = "server=it154484.mysql.database.azure.com;database=it185158;uid=it185158;password=Ogma123!;";
        
        

        public FetchData()
        {
           // this.connectionString = connectionString;
        }

        public DataTable FetchDataFromTable()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"SELECT modulecategories.idCategory, modulecategories.idModule, categories.CategoryName FROM modulecategories JOIN categories ON modulecategories.idCategory = categories.idCategory";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    return dataTable;
                }
            }
        }
    }
}
