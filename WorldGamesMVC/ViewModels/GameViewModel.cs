using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Models.Enums;

namespace WorldGamesMVC.ViewModels
{
    public class GameViewModel
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public Plataforma Plataforma { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Preco { get; set; }
    }
}
