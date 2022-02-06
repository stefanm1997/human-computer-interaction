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
    [Table("igrac")]
    class Player : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public Player()
        {
        }

        public Player(int iD, string name, string surname, DateTime dateOfBirth, string placeOfBirth,
            string citizenship, string position, int height, int weight, double price, string foot)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            Citizenship = citizenship;
            Position = position;
            Height = height;
            Weight = weight;
            Price = price;
            Foot = foot;
        }

        public Player(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override string ToString()
        {
            return Name +" "+ Surname;
        }

        [Key]
        [Column("idIgraca")]
        public int ID { get; set; }

        [Column("Ime")]
        public string Name { get; set; }

        [Column("Prezime")]
        public string Surname { get; set; }

        [Column("DatumRodjenja")]
        public DateTime DateOfBirth { get; set; }

        [Column("MjestoRodjenja")]
        public string PlaceOfBirth { get; set; }

        [Column("Drzavljanstvo")]
        public string Citizenship { get; set; }

        [Column("Pozicija")]
        public string Position { get; set; }

        [Column("Visina")]
        public int Height { get; set; }

        [Column("Tezina")]
        public int Weight { get; set; }

        [Column("Cijena")]
        public double Price { get; set; }

        [Column("Noga")]
        public string Foot { get; set; }


    }
}
