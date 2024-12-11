using MySqlConnector;

namespace AffirmationApp
{
    public class DatabaseClass
    {
        private string connectionString = "Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;";



        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
