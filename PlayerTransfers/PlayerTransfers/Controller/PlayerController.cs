using MySql.Data.MySqlClient;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Controller
{
    class PlayerController
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PlayerTransfers"].ConnectionString;

        public bool AddPlayer(Player player)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var ply = context.Players.Add(player);
                    if (ply == null)
                    {
                        return false;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<Player> AllPlayers()
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var players = context.Players.ToList();
                    return players;
                }
            }
        }

        public int GetIDFromNameAndSurname(string name, string surname)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.Name.Equals(name) && u.Surname.Equals(surname)).SingleOrDefault();
                    if (ply == null)
                        return 0;
                    return ply.ID;
                }
            }
        }

        public string GetNameFromID(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.ID == id).SingleOrDefault();
                    if (ply == null)
                        return "";
                    return ply.Name;
                }
            }
        }

        public string GetSurnameFromID(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.ID == id).SingleOrDefault();
                    if (ply == null)
                        return "";
                    return ply.Surname;
                }
            }
        }

        public string GetPositionFromID(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.ID == id).SingleOrDefault();
                    if (ply == null)
                        return "";
                    return ply.Position;
                }
            }
        }

        public Player GetPlayerFromID(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.ID == id).SingleOrDefault();
                    if (ply == null)
                        return null;
                    return ply;
                }
            }
        }
        public bool UpdatePlayer(Player player)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.ID == player.ID).SingleOrDefault();
                    if (ply == null)
                        return false;
                    ply.Name = player.Name;
                    ply.Surname = player.Surname;
                    ply.Citizenship = player.Citizenship;
                    ply.DateOfBirth = player.DateOfBirth;
                    ply.Foot = player.Foot;
                    ply.Height = ply.Height;
                    ply.PlaceOfBirth = player.PlaceOfBirth;
                    ply.Position = player.Position;
                    ply.Price = player.Price;
                    ply.Weight = player.Weight;
                    context.Entry(ply).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeletePlayer(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Player(connection, false))
                {
                    var ply = context.Players.Where(u => u.ID == id).SingleOrDefault();
                    if (ply == null)
                        return false;
                    context.Players.Remove(ply);
                    context.SaveChanges();
                    return true;
                }
            }
        }

    }
}
