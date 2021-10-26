using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Repositories.Interfaces;

namespace WorldGamesMVC.Services
{
    public class GamesService
    {
        private readonly IGameRepository _gameRepository;

        public GamesService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

     

    }
}
