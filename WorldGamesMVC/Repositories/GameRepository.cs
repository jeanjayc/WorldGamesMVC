using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorldGamesMVC.Context;
using WorldGamesMVC.Models;
using WorldGamesMVC.Repositories.Interfaces;
using WorldGamesMVC.ViewModels;

namespace WorldGamesMVC.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Game entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var result = await (from game in _context.Games
                                join gen in _context.Generos on game.GeneroId equals gen.GeneroId
                                select new
                                {
                                    game.Titulo,
                                    game.Imagem,
                                    game.Genero,
                                    game.Lancamento,
                                    game.Plataforma,
                                    game.Preco,
                                    game.DescricaoCurta,
                                    game.DescricaoCompleta,
                                    gen.GeneroNome
                                }).ToListAsync();

            var games = new List<Game>();
            foreach(var item in result)
            {
                var game = new Game();
                game.Titulo = item.Titulo;
                game.Imagem = item.Imagem;
                game.Genero = item.Genero;
                game.Lancamento = item.Lancamento;
                game.Plataforma = item.Plataforma;
                game.Preco = item.Preco;
                game.DescricaoCurta = item.DescricaoCurta;

                games.Add(game);
            }
            return games;

            //var result = await _context.Games
            //.Join(_context.Generos, game => game.GameId, genero => genero.GeneroId,
            //(game, genero) => new { Game = game, Genero = genero })
            //.Select(g => new {
            //    Titulo = g.Game.Titulo,
            //    Genero = g.Genero.GeneroNome,
            //    Lancamento = g.Game.Lancamento,
            //    Plataforma = g.Game.Plataforma
            //}).ToListAsync();
        }

        public Task<Game> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Game entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> Search(Expression<Func<Game, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Update(Game entity)
        {
            throw new NotImplementedException();
        }
    }
    
}
