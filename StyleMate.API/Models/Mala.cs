using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace StyleMateAPI.Models
=======
namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class Mala
    {
        [Key]
        public int IdMala { get; set; }
        public string Nome { get; set; }
        public string Destino { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public int IdUtilizador { get; set; }
        public Utilizador Utilizador { get; set; }

        public ICollection<MalaConjunto>? MalaConjuntos { get; set; }
    }
}
