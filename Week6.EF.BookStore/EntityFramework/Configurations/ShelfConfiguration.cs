using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EF.BookStore.Core.Models;

namespace Week6.EF.BookStore.EntityFramework.Configurations
{
    public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.ToTable("Shelves"); //potrei passare un altro nome alla tabella
            builder.HasKey(s => s.Id); //chiave primaria
            builder.Property("Code") //oppure s => s.Code
                .IsRequired().HasMaxLength(6);
        }
    }
}
