using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Models;

namespace WorldGamesMVC.Repositories.Interfaces
{
    
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetAll();
    }
}
