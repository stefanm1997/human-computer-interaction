using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTransfers.Model
{
    [Table("transfer")]
    class Transfer : DbContext
    {
        public DbSet<Transfer> Transfers { get; set; }
        public Transfer()
        {
        }
        public Transfer(DbConnection existingConnection, bool contextOwnsConnection) :
           base(existingConnection, contextOwnsConnection)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

        [Key]
        [Column("idTransfera")]
        public int idTransfer { get; set; }

        [Column("DatumTransfera")]
        public DateTime Date { get; set; }

        [Column("Cijena")]
        public double Price { get; set; }

        [Column("KLUB_idKluba1")]
        //[ForeignKey("KLUB_idKluba1")]
        public int? idClub1 { get; set; }

        //[ForeignKey("KLUB_idKluba2")]
        [Column("KLUB_idKluba2")]
        public int? idClub2 { get; set; }

        //[ForeignKey("IGRAC_idIgraca")]
        [Column("IGRAC_idIgraca")]
        public int idPlayer { get; set; }
    }
}
