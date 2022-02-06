using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Model
{
    [Table("ugovor_klub_igrac")]
    class Contract : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public Contract()
        {
        }

        public Contract(DbConnection existingConnection, bool contextOwnsConnection) :
           base(existingConnection, contextOwnsConnection)
        {
        }

        public Contract(DbSet<Contract> contracts, int idContract, DateTime dateFrom, 
            DateTime dateTo, double salary, int number, string jersey, int idClub, int idPlayer)
        {
            Contracts = contracts;
            this.idContract = idContract;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Salary = salary;
            Number = number;
            Jersey = jersey;
            this.idClub = idClub;
            this.idPlayer = idPlayer;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        [Key]
        [Column("idUgovora")]
        public int idContract { get; set; }

        [Column("DatumOd")]
        public DateTime DateFrom { get; set; }

        [Column("DatumDo")]
        public DateTime DateTo { get; set; }

        [Column("Plata")]
        public double Salary { get; set; }

        [Column("Broj")]
        public int Number { get; set; }

        [Column("Natpis")]
        public string Jersey { get; set; }

        [Column("KLUB_idKluba")]
        public int idClub { get; set; }
        /*[ForeignKey("KLUB_idKluba")]
        public virtual Club Club { get; set; }*/

        [Column("IGRAC_idIgraca")]
        public int idPlayer { get; set; }
        /*[ForeignKey("IGRAC_idIgraca")]
        public virtual Player Player { get; set; }*/

    }
}
