using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EntityFramework.Core.Models;

namespace Week6.EntityFramework.EntityFramework
{
    public class KnightsContext :   DbContext
    {
        //Proprietà di tipo DbSet (una per ogni entità che voglio mappare sul database)
        public DbSet<Knight> Knights { get; set; } //così chiamo la tabella Knights sul db ( se non faccio un altro tipo di mapping)

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;
Database=KnightsDb;Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //qui dentro descrivo la relazione molti a molti
            modelBuilder.Entity<Knight>()
                .HasMany(k => k.Battles)
                .WithMany(b => b.Knights)
                .UsingEntity<BattleKnight>(bk => bk.HasOne<Battle>().WithMany(),
                bk => bk.HasOne<Knight>().WithMany())
                //.ToTable("XYZbattleKnight") //per mappare su una tabella con il nome che gli passo
                .Property(bk => bk.DateJoined);
            //.HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<BattleKnight>()
                .Property(bk => bk.KnightId)
                .HasColumnName("KnightsId"); //cambio il nome 

            modelBuilder.Entity<BattleKnight>()
                .Property(bk => bk.BattleId)
                .HasColumnName("BattlesBattleId"); //cambio il nome 
        }
    }
}
