using MySql.Data.EntityFramework;
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
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    [Table("korisnik")]
    class User : DbContext
    {

        public DbSet<User> Users { get; set; }
        public User() : base()
        {
        }

        public User(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {

        }

        public User(int id, string name, string surname, string username, string password, string role)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Role = role;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().MapToStoredProcedures();
            modelBuilder.Entity<User>().ToTable("korisnik");
        }

        [Key]
        [Column("idKorisnika")]
        public int ID { get; set; }

        [Column("Ime")]
        public string Name { get; set; }

        [Column("Prezime")]
        public string Surname { get; set; }

        [Column("Korisnicko_ime")]
        public string Username { get; set; }

        [Column("Lozinka")]
        public string Password { get; set; }

        [Column("Uloga")]
        public string Role { get; set; }
    }
}
