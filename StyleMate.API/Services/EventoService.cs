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
    public class EventoService
    {
        private readonly EventoRepository _repo;

        public EventoService(EventoRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Evento>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Evento?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<List<Evento>> GetByUserAsync(int idUtilizador) => _repo.GetByUserAsync(idUtilizador);
        public Task<Evento> CreateAsync(Evento evento) => _repo.AddAsync(evento);
        public Task UpdateAsync(Evento evento) => _repo.UpdateAsync(evento);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
