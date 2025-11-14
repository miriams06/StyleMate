using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using StyleMateAPI.Data;
using StyleMateAPI.Models;

namespace StyleMateAPI.Repositories
=======
using StyleMate1._1.Data;
using StyleMate1._1.Models;

namespace StyleMate1._1.Repositories
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class UtilizadorRepository : GenericRepository<Utilizador>
    {
        public UtilizadorRepository(StyleMateContext context) : base(context) { }

<<<<<<< HEAD
        public async Task<Utilizador?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Utilizador?> GetByExternalIdAsync(string externalId)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.ExternalId == externalId);
=======
        public async Task<List<Utilizador>> GetAllAsync()
           => await _context.Utilizadores.ToListAsync();

        public async Task<Utilizador?> GetByIdAsync(int id)
            => await _context.Utilizadores.FindAsync(id);

        public async Task<Utilizador?> GetByEmailAsync(string email)
            => await _context.Utilizadores.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<Utilizador?> GetByExternalIdAsync(string externalId)
            => await _context.Utilizadores.FirstOrDefaultAsync(u => u.ExternalId == externalId);

        public async Task AddAsync(Utilizador u)
        {
            _context.Utilizadores.Add(u);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Utilizador u)
        {
            _context.Utilizadores.Update(u);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Utilizador u)
        {
            _context.Utilizadores.Remove(u);
            await _context.SaveChangesAsync();
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
        }
    }
}
