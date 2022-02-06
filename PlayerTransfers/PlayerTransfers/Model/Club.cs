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
    [Table("klub")]
    class Club : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public Club()
        {
        }

        public Club(int iD, string clubName, string league, DateTime foundationDate, string address, string phone, string stadium)
        {
            ID = iD;
            ClubName = clubName;
            League = league;
            FoundationDate = foundationDate;
            Address = address;
            Phone = phone;
            Stadium = stadium;
        }

        public Club(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override string ToString()
        {
            return ClubName;
        }

        [Key]
        [Column("idKluba")]
        public int ID { get; set; }

        [Column("NazivKluba")]
        public string ClubName { get; set; }

        [Column("Liga")]
        public string League { get; set; }

        [Column("DatumOsnivanja")]
        public DateTime FoundationDate { get; set; }

        [Column("Adresa")]
        public string Address { get; set; }

        [Column("Telefon")]
        public string Phone { get; set; }

        [Column("NazivStadiona")]
        public string Stadium { get; set; }
    }
}
