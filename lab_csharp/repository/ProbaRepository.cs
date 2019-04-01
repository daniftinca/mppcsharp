using System;
using System.Collections.Generic;
using lab_c.Model;
using MySql.Data.MySqlClient;

namespace lab_c.Repository
{
    public class ProbaRepository : IRepository<int, Proba>
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        UserRepository userRepository = new UserRepository();

        public void save(Proba entity)
        {
            MySqlConnection connection = databaseConnection.getConnection();
            using (connection)
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO proba VALUES (@id,@nume,@idArbitru)", connection);

                cmd.Parameters.AddWithValue("@nume", entity.Name);
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@idArbitru", entity.Arbitru.Id);
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
                MySqlCommand cmd = new MySqlCommand("Delete from proba where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Proba findOne(int id)
        {
            MySqlConnection connection = databaseConnection.getConnection();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from proba where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        User user = userRepository.findOne(Convert.ToInt32(reader["IDArbitru"]));
                        return new Proba(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString(),
                            user);
                    }
                    return null;
                }

            }
        }

        public List<Proba> findAll()
        {
            MySqlConnection connection = databaseConnection.getConnection();
           
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from proba", connection);
                List<Proba> list = new List<Proba>();
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = userRepository.findOne(Convert.ToInt32(reader["IDArbitru"]));
                        list.Add(new Proba(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString(),
                            user));
                        
                    }
                    return list;
                }

            }
           
        }

        public List<Proba> findAllForArbitru(User arbitru)
        {
            MySqlConnection connection = databaseConnection.getConnection();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from proba where IDArbitru = @idArbitru", connection);
                List<Proba> list = new List<Proba>();
                cmd.Parameters.AddWithValue("@idArbitru",arbitru.Id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        User user = userRepository.findOne(Convert.ToInt32(reader["IDArbitru"]));
                        list.Add(new Proba(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString(),
                            user));

                    }
                    return list;
                }


            }

        }
    }
}