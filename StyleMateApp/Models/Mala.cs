using System.ComponentModel.DataAnnotations;

namespace StyleMateApp.Models
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

