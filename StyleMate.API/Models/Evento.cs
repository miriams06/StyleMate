using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace StyleMateAPI.Models
=======
namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        public string Nome { get; set; }
        public DateTime DataEvento { get; set; }
        public string Local { get; set; }
        public string TipoEvento { get; set; }

        public int IdUtilizador { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
