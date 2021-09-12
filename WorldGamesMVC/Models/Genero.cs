using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldGamesMVC.Models
{
    public class Genero
    {
        
        public int GeneroId { get; set; }

        [Column(TypeName ="varchar(100)")]
        public string GeneroNome { get; set; }
        public List<Game> Games { get; set; }
    }
}
