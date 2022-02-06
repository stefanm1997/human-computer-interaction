using MySql.Data.MySqlClient;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Controller
{
    class UserController
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PlayerTransfers"].ConnectionString;

        public bool AddUser(User user)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new User(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var usr = context.Users.Where(u => u.Username.Equals(user.Username)).FirstOrDefault();
                    if (usr != null)
                        return false;
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<User> AllUsers()
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new User(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var user = context.Users.ToList();
                    return user;
                }
            }
        }

        public string UserRole(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new User(connection, false))
                {
                    var user = context.Users.Where(u => u.ID == id).FirstOrDefault();
                    if (user == null)
                        return "";
                    return user.Role;
                }
            }
        }
    }
}
