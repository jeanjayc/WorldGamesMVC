using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Models;

namespace WorldGamesMVC.Context.Mappings
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");
            builder.HasKey(g => g.GameId);
            builder.Property(g => g.Titulo).HasColumnType("varchar(50)").IsRequired();
            builder.Property(g => g.ImagemThumb).HasColumnType("varchar(300)");
            builder.Property(g => g.Imagem).HasColumnType("varchar(300)");
            builder.Property(g => g.DescricaoCurta).HasColumnType("varchar(100)");
            builder.Property(g => g.DescricaoCompleta).HasColumnType("varchar(500)");
            builder.Property(g => g.Plataforma).IsRequired();
            builder.Property(g => g.Lancamento).HasColumnType("DATETIME").IsRequired();
            builder.Property(g => g.Preco).HasColumnType("FLOAT(10,6)");
            builder.Property(g => g.Ativo).HasColumnType("tinyint");
        }
    }
}
