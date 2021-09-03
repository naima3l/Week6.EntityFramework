using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.GestioneSpese.Core.Models;

namespace Week6.EF.GestioneSpese.EF
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Shopping> Shoppings { get; set; }

        //[MaxLength(6)]
        public DbSet<Category> Category { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;
Database=GestioneSpese;Trusted_Connection = True;");
        }
        
    }
}
