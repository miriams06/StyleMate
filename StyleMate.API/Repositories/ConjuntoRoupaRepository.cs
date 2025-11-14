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
    public class ConjuntoRoupaRepository
    {
        private readonly StyleMateContext _context;

        public ConjuntoRoupaRepository(StyleMateContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ConjuntoRoupa cr)
        {
            _context.ConjuntoRoupas.Add(cr);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int idConjunto, int idRoupa)
        {
            var entity = await _context.ConjuntoRoupas
                .FirstOrDefaultAsync(c => c.IdConjunto == idConjunto && c.IdRoupa == idRoupa);

            if (entity != null)
            {
                _context.ConjuntoRoupas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Roupa>> GetRoupasDoConjuntoAsync(int idConjunto)
        {
            return await _context.ConjuntoRoupas
                .Where(cr => cr.IdConjunto == idConjunto)
                .Include(cr => cr.Roupa)
                .Select(cr => cr.Roupa)
                .ToListAsync();
        }

        public async Task<List<Conjunto>> GetConjuntosDaRoupaAsync(int idRoupa)
        {
            return await _context.ConjuntoRoupas
                .Where(cr => cr.IdRoupa == idRoupa)
                .Include(cr => cr.Conjunto)
                .Select(cr => cr.Conjunto)
                .ToListAsync();
        }
    }
}
