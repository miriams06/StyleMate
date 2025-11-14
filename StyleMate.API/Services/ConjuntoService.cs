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
    public class ConjuntoService
    {
        private readonly ConjuntoRepository _repo;

        public ConjuntoService(ConjuntoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Conjunto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Conjunto?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<List<Conjunto>> GetByUserAsync(int idUtilizador) => await _repo.GetByUserAsync(idUtilizador);

        public async Task<Conjunto> CreateAsync(Conjunto c)
        {
            await _repo.AddAsync(c);
            return c;
        }

        public async Task UpdateAsync(Conjunto c)
        {
            await _repo.UpdateAsync(c);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity != null) await _repo.DeleteAsync(entity);
        }
    }
}
