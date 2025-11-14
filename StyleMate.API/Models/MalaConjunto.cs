<<<<<<< HEAD
﻿namespace StyleMateAPI.Models
=======
﻿namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class MalaConjunto
    {
        public int IdMala { get; set; }
        public int IdConjunto { get; set; }

        public Mala Mala { get; set; }
        public Conjunto Conjunto { get; set; }
    }
}