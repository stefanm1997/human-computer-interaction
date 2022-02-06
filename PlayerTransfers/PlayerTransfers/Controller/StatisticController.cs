using MySql.Data.MySqlClient;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Controller
{
    class StatisticController
    {

        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PlayerTransfers"].ConnectionString;

        public bool AddPlayerStatistic(PlayerStatistic statistic)
        {
            var insertPerson = "INSERT INTO statistika_igraca(KLUB_idKluba, IGRAC_idIgraca, Sezona, OdigranihUtakmica, Golova, Asistencija, BrojKartona)" +
                " VALUES(@idKluba, @idIgraca, @Sezona, @OdigranihUtakmica, @Golova, @Asistencija, @BrojKartona)";
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                /* var cmd = connection.CreateCommand();
                 cmd.CommandText = insertPerson;
                 //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@idKluba", statistic.IdClub);
                 cmd.Parameters.AddWithValue("@idIgraca", statistic.IDPlayer);
                 cmd.Parameters.AddWithValue("@Sezona", statistic.Season);
                 cmd.Parameters.AddWithValue("@OdigranihUtakmica", statistic.PlayedGames);
                 cmd.Parameters.AddWithValue("@Golova", statistic.Goals);
                 cmd.Parameters.AddWithValue("@Asistencija", statistic.Assists);
                 cmd.Parameters.AddWithValue("@BrojKartona", statistic.Cards);
                 cmd.ExecuteNonQuery();
                 return true;*/
                using (var context = new PlayerStatistic(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var sts = context.Statistics.Add(statistic);
                    if (sts == null)
                    {
                        return false;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<PlayerStatistic> AllStatistic()
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new PlayerStatistic(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var statistic = context.Statistics.ToList();
                    return statistic;
                }
            }
        }
        public bool UpdateStatistic(PlayerStatistic statistic)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new PlayerStatistic(connection, false))
                {
                    var sts = context.Statistics.Where(u => u.Sezona.Equals(statistic.Sezona) && u.KLUB_idKluba == statistic.KLUB_idKluba && u.IGRAC_idIgraca == statistic.IGRAC_idIgraca).SingleOrDefault();
                    var oldsts = sts;
                    //context.Statistics.Remove(oldsts);
                    if (sts == null)
                        return false;
                    sts.Sezona = statistic.Sezona;
                    sts.PlayedGames = statistic.PlayedGames;
                    sts.Goals = statistic.Goals;
                    sts.Assists = statistic.Assists;
                    sts.Cards = statistic.Cards;
                    context.Entry(sts).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteStatistic(int idPlayer, int idClub, string Season)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new PlayerStatistic(connection, false))
                {
                    var sts = context.Statistics.Where(u => u.Sezona.Equals(Season) && u.KLUB_idKluba == idClub && u.IGRAC_idIgraca == idPlayer)
                        .SingleOrDefault();
                    if (sts == null)
                        return false;
                    context.Statistics.Remove(sts);
                    context.SaveChanges();
                    return true;
                }
            }
        }

    }
}
