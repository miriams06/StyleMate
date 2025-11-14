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
    public class UtilizadorService
    {
        private readonly UtilizadorRepository _repo;

        public UtilizadorService(UtilizadorRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Utilizador>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Utilizador?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<Utilizador?> GetByEmailAsync(string email) => await _repo.GetByEmailAsync(email);

        public async Task<Utilizador?> GetByExternalIdAsync(string externalId) => await _repo.GetByExternalIdAsync(externalId);

        public async Task<Utilizador> CreateAsync(Utilizador u)
        {
            u.DataRegisto = DateTime.UtcNow;
            await _repo.AddAsync(u);
            return u;
        }

        public async Task UpdateAsync(Utilizador u)
        {
            await _repo.UpdateAsync(u);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity != null) await _repo.DeleteAsync(entity);
        }
<<<<<<< HEAD
=======
        public async Task<Utilizador> CreateOrUpdateExternalAsync(
            string email,
            string externalId,
            string nome)
        {
            var user = await _repo.GetByExternalIdAsync(externalId);

            if (user == null)
            {
                // Primeiro login → cria utilizador
                user = new Utilizador
                {
                    Nome = nome,
                    Email = email,
                    ExternalId = externalId,
                    DataRegisto = DateTime.UtcNow
                };

                await _repo.AddAsync(user);
            }
            else
            {
                // Utilizador já existe → atualizar info
                user.Nome = nome;
                user.Email = email;

                await _repo.UpdateAsync(user);
            }

            return user;
        }
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
    }
}
