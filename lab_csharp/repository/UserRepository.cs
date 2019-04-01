using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using lab_c.Model;
using MySql.Data.MySqlClient;

namespace lab_c.Repository
{
    public class UserRepository : IRepository<int, User>
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public void save(User entity)
        {

            MySqlConnection connection = databaseConnection.getConnection();
            using (connection)
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO users VALUES (@id,@username,@password,@name)", connection);
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@username", entity.Username);
                cmd.Parameters.AddWithValue("@password", entity.Password);
                cmd.Parameters.AddWithValue("@name", entity.Name);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void delete(int id)
        {
            MySqlConnection connection = databaseConnection.getConnection();
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Delete from users where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public User findOne(int id)
        {
            MySqlConnection connection = databaseConnection.getConnection();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from users where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                       
                        return new User(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString(),
                            reader["username"].ToString(),
                            reader["password"].ToString());
                    }
                }
                connection.Close();

            }

            return null;
        }

        public User findByUsername(String username)
        {
            MySqlConnection connection = databaseConnection.getConnection();


            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from users where username=@username", connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new User(
                           Convert.ToInt32(reader["ID"]),
                           reader["name"].ToString(),
                           reader["username"].ToString(),
                           reader["password"].ToString()
                           );
                    }
                }
                connection.Close();

            }

            return null;
        }

        public List<User> findAll()
        {
            MySqlConnection connection = databaseConnection.getConnection();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from users", connection);
                List<User> list = new List<User>();
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        list.Add(new User(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString(),
                            reader["username"].ToString(),
                            reader["password"].ToString()
                            ));
                        
                    }
                    return list;
                }


            }
        }
    }
}