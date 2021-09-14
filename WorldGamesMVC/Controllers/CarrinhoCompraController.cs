using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorldGamesMVC.Models;
using WorldGamesMVC.Repositories.Interfaces;
using WorldGamesMVC.ViewModels;

namespace WorldGamesMVC.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly CarrinhoCompra _carrinhoCompra;
        public CarrinhoCompraController(IGameRepository gameRepository,
                                        CarrinhoCompra carrinhoCompra)
        {
            _gameRepository = gameRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraVM
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };

        return View(carrinhoCompraVM);
        }

        public async Task<RedirectToActionResult> AdicionarItemNoCarrinhoCompra(int gameId)
        {
            var gameSelecionado = await _gameRepository.GetById(gameId);

            if(gameSelecionado != null)
            {
                 _carrinhoCompra.AdicionarAoCarrinho(gameSelecionado);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoverItemDoCarrinhoCompra(int gameId)
        {
            var gameSelecionado = await _gameRepository.GetById(gameId);

            if (gameSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(gameSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
