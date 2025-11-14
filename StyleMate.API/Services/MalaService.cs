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
    public class MalaService
    {
        private readonly MalaRepository _repo;

        public MalaService(MalaRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Mala>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Mala?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<List<Mala>> GetByUserAsync(int idUtilizador) => _repo.GetByUserAsync(idUtilizador);
        public Task<Mala> CreateAsync(Mala mala) => _repo.AddAsync(mala);
        public Task UpdateAsync(Mala mala) => _repo.UpdateAsync(mala);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
