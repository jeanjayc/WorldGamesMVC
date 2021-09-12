using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Repositories.Interfaces;
using WorldGamesMVC.ViewModels;

namespace WorldGamesMVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeneroRepository _generoRepository;
        public GamesController(IGameRepository gameRepository, IGeneroRepository generoRepository)
        {
            _gameRepository = gameRepository;
            _generoRepository = generoRepository;
        }

        public async Task<IActionResult> List()
        {
            //ViewBag.Game = "Games";
            //ViewData["Genero"] = "Genero";
       
            var games = await _gameRepository.GetAll();

            return View(games);

        }
    }
}
