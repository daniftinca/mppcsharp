using lab_c.Model;
using lab_c.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.repository
{
    public class ParticipantRepository : IRepository<int, Participant>
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();


        public void save(Participant entity)
        {
            MySqlConnection connection = databaseConnection.getConnection();
            using (connection)
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO participants VALUES (@id,@nume)", connection);
                cmd.Parameters.AddWithValue("@nume", entity.Id);
                cmd.Parameters.AddWithValue("@nume", entity.Name);
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
                MySqlCommand cmd = new MySqlCommand("Delete from participants where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Participant findOne(int id)
        {
            MySqlConnection connection = databaseConnection.getConnection();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from participants where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        return new Participant(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString());
                    }
                }
                connection.Close();

            }

            return null;
        }

        public List<Participant> findAll()
        {
            MySqlConnection connection = databaseConnection.getConnection();
           
            
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from participants", connection);
                List<Participant> list = new List<Participant>();
                
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        list.Add(new Participant(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString()));
                      
                    }
                    return list;
                }
                connection.Close();

            }

            return null;
        }

        public List<Participant> getParticipantWithNoScoreForProba(Proba proba) {
            MySqlConnection connection = databaseConnection.getConnection();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from participants p " +
                                                    "where p.ID not in " +
                                                    "(select IDparticipant " +
                                                    "from scores s " +
                                                    "inner join proba pr " +
                                                    "on pr.ID=s.IDProba " +
                                                    "where IDProba=@id)", connection);
                List<Participant> list = new List<Participant>();
                cmd.Parameters.AddWithValue("@id", proba.Id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        list.Add(new Participant(
                            Convert.ToInt32(reader["ID"]),
                            reader["name"].ToString()));

                    }
                    return list;
                }
            }
        }
    }   
          
}

