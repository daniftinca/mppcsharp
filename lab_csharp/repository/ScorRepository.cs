using lab_c.Model;
using lab_c.Repository;
using lab_csharp.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_csharp.repository
{
    public class ScorRepository : IRepository<int, Scor>

    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        ParticipantRepository participantRepository = new ParticipantRepository();
        ProbaRepository probaRepository = new ProbaRepository();

        public void save(Scor entity)
        {
            MySqlConnection connection = databaseConnection.getConnection();
            using (connection)
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO scores VALUES (@id,@idParticipant,@idProba,@score)", connection);
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@idParticipant", entity.Participant.Id);
                cmd.Parameters.AddWithValue("@idProba", entity.Proba.Id);
                cmd.Parameters.AddWithValue("@score", entity.Score);
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
                MySqlCommand cmd = new MySqlCommand("Delete from scores where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Scor findOne(int id)
        {
            MySqlConnection connection = databaseConnection.getConnection();
            ParticipantRepository participantRepository = new ParticipantRepository();
            ProbaRepository probaRepository = new ProbaRepository();

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from scores where id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Participant participant = participantRepository.findOne(Convert.ToInt32(reader["id_participant"]));
                        Proba proba = probaRepository.findOne(Convert.ToInt32(reader["id_proba"]));

                         return new Scor(
                            Convert.ToInt32(reader["ID"]),
                            participant,
                            proba,
                            Convert.ToInt32(reader["score"])
                            );
                    }
                }
                connection.Close();

            }

            return null;
        }

        public List<Scor> findAll()
        {
            MySqlConnection connection = databaseConnection.getConnection();
           

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from scores", connection);
                List<Scor> list = new List<Scor>();
                
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Participant participant = participantRepository.findOne(Convert.ToInt32(reader["IDParticipant"]));

                        Proba proba = probaRepository.findOne(Convert.ToInt32(reader["IDProba"]));

                        list.Add(new Scor(
                            Convert.ToInt32(reader["ID"]),
                            participant,
                            proba,
                            Convert.ToInt32(reader["score"])));
                        
                    }
                    return list;
                }

            }
        }

        public List<Scor> getScoresFromProba(Proba proba)
        {
            MySqlConnection connection = databaseConnection.getConnection();
            

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from participants p Inner join scores s on p.ID = s.IDParticipant inner join proba pr on s.IDProba = pr.ID where pr.ID = @id order by s.score desc", connection);
                List<Scor> list = new List<Scor>();
                cmd.Parameters.AddWithValue("@id", proba.Id);
                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Participant participant = participantRepository.findOne(Convert.ToInt32(reader["IDParticipant"]));

                        list.Add(new Scor(
                            Convert.ToInt32(reader["ID"]),
                            participant,
                            proba,
                            Convert.ToInt32(reader["score"])));

                    }
                    return list;
                }

            }

        }

        public List<ScoreTotal> getScoreTotals() {
            MySqlConnection connection = databaseConnection.getConnection();
            

            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select p.name as Name, sum(score) as TotalScore from participants p inner join scores s on p.ID=s.IDParticipant group by p.name", connection);
                List<ScoreTotal> list = new List<ScoreTotal>();

                cmd.Prepare();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())                   {
                      

                        list.Add(new ScoreTotal(                            
                            reader["Name"].ToString(),
                            Convert.ToInt32(reader["TotalScore"])));

                    }
                    return list;
                }
            }
        }
    }

      
}

