<<<<<<< HEAD
﻿using StyleMateAPI.Models;
using StyleMateAPI.Repositories;

namespace StyleMateAPI.Services
=======
﻿using StyleMate1._1.Models;
using StyleMate1._1.Repositories;

namespace StyleMate1._1.Services
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class ConjuntoRoupaService
    {
        private readonly ConjuntoRoupaRepository _repo;

        public ConjuntoRoupaService(ConjuntoRoupaRepository repo)
        {
            _repo = repo;
        }

        public Task AddAsync(ConjuntoRoupa cr) => _repo.AddAsync(cr);
        public Task RemoveAsync(int idConjunto, int idRoupa) => _repo.RemoveAsync(idConjunto, idRoupa);
        public Task<List<Roupa>> GetRoupasDoConjuntoAsync(int idConjunto) => _repo.GetRoupasDoConjuntoAsync(idConjunto);
        public Task<List<Conjunto>> GetConjuntosDaRoupaAsync(int idRoupa) => _repo.GetConjuntosDaRoupaAsync(idRoupa);
    }
}
