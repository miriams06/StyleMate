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
    public class MalaRepository
    {
        private readonly StyleMateContext _context;

        public MalaRepository(StyleMateContext context)
        {
            _context = context;
        }

        public async Task<List<Mala>> GetAllAsync() =>
            await _context.Malas.Include(m => m.Utilizador).ToListAsync();

        public async Task<Mala?> GetByIdAsync(int id) =>
            await _context.Malas.Include(m => m.MalaConjuntos)
                                .ThenInclude(mc => mc.Conjunto)
                                .FirstOrDefaultAsync(m => m.IdMala == id);

        public async Task<List<Mala>> GetByUserAsync(int idUtilizador) =>
            await _context.Malas.Where(m => m.IdUtilizador == idUtilizador).ToListAsync();

        public async Task<Mala> AddAsync(Mala mala)
        {
            _context.Malas.Add(mala);
            await _context.SaveChangesAsync();
            return mala;
        }

        public async Task UpdateAsync(Mala mala)
        {
            _context.Malas.Update(mala);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mala = await _context.Malas.FindAsync(id);
            if (mala != null)
            {
                _context.Malas.Remove(mala);
                await _context.SaveChangesAsync();
            }
        }
    }
}
