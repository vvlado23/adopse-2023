
using System;
using MySql.Data.MySqlClient;

namespace ADOPSE_2023

{
    public class UserAuth
    {

        

        public bool RegisterUser(string email, string username, string password)
        {
            MySqlConnection connection = DatabaseConnection.GetConnection();

            // Check if the user already exists
            if (UserExists(username))
            {
                Console.WriteLine("User already exists.");
                return false;
            }
            try
            {

                Console.WriteLine("Trying to register");
                string query = "INSERT INTO Users (Email, Username, Password) VALUES (@Email, @Username, @Password)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("User registered successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during user registration: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


            public bool LoginUser(string username, string password)
            {

            MySqlConnection connection = DatabaseConnection.GetConnection();

            try
                {
                    //connection.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("User logged in successfully.");
                            return true;
                        }
                    }

                    Console.WriteLine("Invalid username or password.");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred during user login: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }

            public bool UserExists(string username)
            {
            MySqlConnection connection = DatabaseConnection.GetConnection();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        connection.Close();
                        return true;
                    }
                }

                connection.Close();
                return false;
            }
    }
}

