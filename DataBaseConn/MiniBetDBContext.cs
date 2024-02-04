using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MiniBet.DataModels;
using System.Net.Mail;

namespace MiniBet.DataBaseConn
{
    public class MiniBetDBContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Invitations> Invitation { get; set; }
        public DbSet<Purchases> Purchase { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Stats> Stat { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public MiniBetDBContext()
        {
            Users = Set<Users>();
            Invitation = Set<Invitations>();
            Purchase = Set<Purchases>();
            Role = Set<Roles>();
            Stat = Set<Stats>();
            Transactions = Set<Transaction>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MiniBet;User Id=dani;Password=123;");

        }


    }
}
