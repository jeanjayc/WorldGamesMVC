using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.Models.Enums;

namespace WorldGamesMVC.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Titulo { get; set; }
        public string ImagemThumb { get; set; }
        public string Imagem { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoCompleta { get; set; }
        public Plataforma Plataforma { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
