using MySql.Data.MySqlClient;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Controller
{
    class TransferController
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PlayerTransfers"].ConnectionString;

        public bool AddTransfer(Transfer transfer)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Transfer(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var trns = context.Transfers.Add(transfer);
                    if (trns == null)
                    {
                        return false;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<Transfer> AllTransfers()
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Transfer(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var transfers = context.Transfers.ToList();
                    return transfers;
                }
            }
        }
    }
}
