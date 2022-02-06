using MySql.Data.MySqlClient;
using PlayerTransfers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Controller
{
    class ContractController
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["PlayerTransfers"].ConnectionString;

        public bool AddContract(Contract contract)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Contract(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var cntr = context.Contracts.Add(contract);
                    if (cntr == null)
                    {
                        return false;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public bool UpdateContract(Contract contract)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Contract(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var cntr = context.Contracts.Where(c => c.idPlayer == contract.idPlayer).FirstOrDefault();
                    if (cntr == null)
                    {
                        return false;
                    }
                    cntr.DateFrom = contract.DateFrom;
                    cntr.DateTo = contract.DateTo;
                    cntr.Jersey = contract.Jersey;
                    cntr.Number = contract.Number;
                    cntr.Salary = contract.Salary;
                    cntr.idClub = contract.idClub;
                    context.Entry(cntr).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<Contract> AllContracts()
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Contract(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var contracts = context.Contracts.ToList();
                    return contracts;
                }
            }
        }

        public int GetClubIdFromPlayerId(int id)
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var context = new Contract(connection, false))
                {
                    //context.Database.Log = (string message) => { Console.WriteLine(message); };
                    var contracts = context.Contracts.Where(c => c.idPlayer == id).FirstOrDefault();
                    if (contracts == null)
                    {
                        return 0;
                    }
                    return contracts.idClub;
                }
            }
        }
    }
}
