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
    [Table("statistika_igraca")]
    class PlayerStatistic : DbContext
    {
        public DbSet<PlayerStatistic> Statistics { get; set; }
          /*public DbSet<Player> Players { get; set; }
           public DbSet<Club> Clubs { get; set; }*/
        public PlayerStatistic()
        {
        }

        public PlayerStatistic(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {
        }

        public PlayerStatistic(DbSet<PlayerStatistic> statistics, int idPlayer, int iD, string season,
            int playedGames, int goals, int assists, int cards)
        {
            Statistics = statistics;
            IGRAC_idIgraca = idPlayer;
            KLUB_idKluba = iD;
            Sezona = season;
            PlayedGames = playedGames;
            Goals = goals;
            Assists = assists;
            Cards = cards;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlayerStatistic>().HasKey(ps => new { ps.Sezona, ps.IGRAC_idIgraca, ps.KLUB_idKluba });
        }

        //[Key, Column(Order = 0)]
        [Key]
        //[ForeignKey("idKluba")]
        [Column("KLUB_idKluba")]
        //[Column(Order = 0)]
        public int KLUB_idKluba { get; set; }
        [ForeignKey("KLUB_idKluba")]
        public virtual Club Club { get; set; }

        //[Key, Column("IGRAC_idIgraca")]
        //[ForeignKey("idIgraca")]
        [Key]
        [Column("IGRAC_idIgraca")]
        /*[ForeignKey("IGRAC_idIgraca")]*/
        //[Column(Order = 1)]
        //[Key]
        //[Key, Column(Order = 1)]
        public int IGRAC_idIgraca { get; set; }
        [ForeignKey("IGRAC_idIgraca")]
        public virtual Player Player {get; set;}

        //[Key, Column(Order = 2)]
        [Key]
        [Column("Sezona")]
        public string Sezona { get; set; }

        [Column("OdigranihUtakmica")]
        public int PlayedGames { get; set; }

        [Column("Golova")]
        public int Goals { get; set; }

        [Column("Asistencija")]
        public int Assists { get; set; }

        [Column("BrojKartona")]
        public int Cards { get; set; }
    }
}
