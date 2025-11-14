namespace StyleMateApp.Models
{
    public class ConjuntoRoupa
    {
        public int IdConjunto { get; set; }
        public int IdRoupa { get; set; }

        public Conjunto Conjunto { get; set; }
        public Roupa Roupa { get; set; }
    }
}