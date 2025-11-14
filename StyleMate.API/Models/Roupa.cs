using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
namespace StyleMateAPI.Models
=======
namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class Roupa
    {
        [Key]
        public int IdRoupa { get; set; }
        public string Nome { get; set; }

        public string CategoriaIA { get; set; }
        public double? CategoriaConfidence { get; set; }
        public string CorIA { get; set; }
        public string EstacaoSugeridaIA { get; set; }

        public string CategoriaUser { get; set; }
        public string CorUser { get; set; }
        public string EstacaoUser { get; set; }

        public string Foto { get; set; }
        public DateTime DataAdicao { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Utilizador))]
        public int IdUtilizador { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
