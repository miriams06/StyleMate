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
    public class MalaConjuntoRepository
    {
        private readonly StyleMateContext _context;

        public MalaConjuntoRepository(StyleMateContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MalaConjunto mc)
        {
            _context.MalaConjuntos.Add(mc);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int idMala, int idConjunto)
        {
            var entity = await _context.MalaConjuntos
                .FirstOrDefaultAsync(mc => mc.IdMala == idMala && mc.IdConjunto == idConjunto);

            if (entity != null)
            {
                _context.MalaConjuntos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Conjunto>> GetConjuntosDaMalaAsync(int idMala)
        {
            return await _context.MalaConjuntos
                .Where(mc => mc.IdMala == idMala)
                .Include(mc => mc.Conjunto)
                .Select(mc => mc.Conjunto)
                .ToListAsync();
        }

        public async Task<List<Mala>> GetMalasDoConjuntoAsync(int idConjunto)
        {
            return await _context.MalaConjuntos
                .Where(mc => mc.IdConjunto == idConjunto)
                .Include(mc => mc.Mala)
                .Select(mc => mc.Mala)
                .ToListAsync();
        }
    }
}
