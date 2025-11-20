using System.ComponentModel.DataAnnotations;


namespace StyleMateAPI.Models

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
