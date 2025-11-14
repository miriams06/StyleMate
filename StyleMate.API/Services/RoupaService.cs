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
    public class RoupaService
    {
        private readonly RoupaRepository _repo;

        public RoupaService(RoupaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Roupa>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Roupa?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<List<Roupa>> GetByUserAsync(int idUtilizador) => await _repo.GetByUserAsync(idUtilizador);

        public async Task<Roupa> CreateAsync(Roupa r)
        {
            r.DataAdicao = DateTime.UtcNow;
            await _repo.AddAsync(r);
            return r;
        }

        public async Task UpdateAsync(Roupa r)
        {
            await _repo.UpdateAsync(r);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity != null) await _repo.DeleteAsync(entity);
        }
    }
}
