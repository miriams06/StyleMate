using System.ComponentModel.DataAnnotations;

namespace StyleMateApp.Models
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

