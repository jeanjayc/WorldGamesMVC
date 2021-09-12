using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorldGamesMVC.Context;
using WorldGamesMVC.Models;
using WorldGamesMVC.Repositories.Interfaces;

namespace WorldGamesMVC.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly AppDbContext _context;

        public GeneroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> GetAll()
        {
            return _context.Generos.ToList();
        }
    }
       
}
