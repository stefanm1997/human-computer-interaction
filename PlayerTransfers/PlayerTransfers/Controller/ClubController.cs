using MySql.Data.MySqlClient;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Controller
{
    class ClubController
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PlayerTransfers"].ConnectionString;

        public bool AddClub(Club club)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var clb = context.Clubs.Add(club);
                    if (clb == null)
                    {
                        return false;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<Club> AllClubs()
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var clubs = context.Clubs.ToList();
                    return clubs;
                }
            }
        }

        public int GetIDFromName(string name)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    var clb = context.Clubs.Where(u => u.ClubName.Equals(name)).SingleOrDefault();
                    if (clb == null)
                        return 0;
                    return clb.ID;
                }
            }
        }

        public string GetNameFromID(int? id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    var clb = context.Clubs.Where(u => u.ID == id).SingleOrDefault();
                    if (clb == null)
                        return "";
                    return clb.ClubName;
                }
            }
        }

        public Club GetClubFromName(string name)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    var clb = context.Clubs.Where(u => u.ClubName == name).SingleOrDefault();
                    if (clb == null)
                        return null;
                    return clb;
                }
            }
        }

        public bool UpdateClub(Club club)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    var clb = context.Clubs.Where(u => u.ID == club.ID).SingleOrDefault();
                    if (clb == null)
                        return false;
                    clb.ClubName = club.ClubName;
                    clb.League = club.League;
                    clb.FoundationDate = club.FoundationDate;
                    clb.Address = club.Address;
                    clb.Phone = club.Phone;
                    clb.Stadium = club.Stadium;
                    context.Entry(clb).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public bool DeleteClub(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Club(connection, false))
                {
                    var clb = context.Clubs.Where(u => u.ID == id).SingleOrDefault();
                    if (clb == null)
                        return false;
                    context.Clubs.Remove(clb);
                    context.SaveChanges();
                    return true;
                }
            }
        }
    }
}
