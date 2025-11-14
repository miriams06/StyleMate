<<<<<<< HEAD
﻿namespace StyleMateAPI.Models
=======
﻿namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class ConjuntoRoupa
    {
        public int IdConjunto { get; set; }
        public int IdRoupa { get; set; }

        public Conjunto Conjunto { get; set; }
        public Roupa Roupa { get; set; }
    }
}