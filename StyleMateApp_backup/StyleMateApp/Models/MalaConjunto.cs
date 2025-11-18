namespace StyleMateApp.Models
{
    public class MalaConjunto
    {
        public int IdMala { get; set; }
        public int IdConjunto { get; set; }

        public Mala Mala { get; set; }
        public Conjunto Conjunto { get; set; }
    }
}