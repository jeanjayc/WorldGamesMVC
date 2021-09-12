using Microsoft.EntityFrameworkCore;
using WorldGamesMVC.Context.Mappings;
using WorldGamesMVC.Models;

namespace WorldGamesMVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { set; get; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameMapping());
        }
    }
}