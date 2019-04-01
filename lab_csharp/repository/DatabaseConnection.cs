using System;
using MySql.Data.MySqlClient;

namespace lab_c.Repository
{
    public class DatabaseConnection
    {
        private MySqlConnection connetion = null;

        public MySqlConnection getConnection()
        {
            String connectionString = "Database=mpp_ex;Data Source=localhost;User id=root;"
                                      + "Password= ;";
            connetion = new MySqlConnection(connectionString);

            return connetion;
        }
    }
}