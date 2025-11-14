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
    public class MalaConjuntoService
    {
        private readonly MalaConjuntoRepository _repo;

        public MalaConjuntoService(MalaConjuntoRepository repo)
        {
            _repo = repo;
        }

        public Task AddAsync(MalaConjunto mc) => _repo.AddAsync(mc);
        public Task RemoveAsync(int idMala, int idConjunto) => _repo.RemoveAsync(idMala, idConjunto);
        public Task<List<Conjunto>> GetConjuntosDaMalaAsync(int idMala) => _repo.GetConjuntosDaMalaAsync(idMala);
        public Task<List<Mala>> GetMalasDoConjuntoAsync(int idConjunto) => _repo.GetMalasDoConjuntoAsync(idConjunto);
    }
}
