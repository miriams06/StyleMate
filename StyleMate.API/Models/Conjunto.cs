using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace StyleMateAPI.Models
=======
namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class Conjunto
    {
        [Key]
        public int IdConjunto { get; set; }
        public string Nome { get; set; }
        public string Estilo { get; set; }
        public string Estacao { get; set; }
        public string Foto { get; set; }

        public int IdUtilizador { get; set; }
        public Utilizador Utilizador { get; set; }

        public ICollection<ConjuntoRoupa>? ConjuntosRoupas { get; set; }
    }
}
