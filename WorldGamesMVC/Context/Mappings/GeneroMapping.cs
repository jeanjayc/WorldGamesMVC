using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Models;

namespace WorldGamesMVC.Context.Mappings
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");
            builder.HasKey(g => g.GeneroId);
            builder.Property(g => g.GeneroNome).HasColumnType("varchar(30)");

            builder.HasMany(g => g.Games)
                .WithOne()
                .HasForeignKey(g => g.GeneroId);
        }
    }
}

