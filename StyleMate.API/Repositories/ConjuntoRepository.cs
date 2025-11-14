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
    public class ConjuntoRepository : GenericRepository<Conjunto>
    {
        public ConjuntoRepository(StyleMateContext context) : base(context) { }

        public async Task<List<Conjunto>> GetByUserAsync(int idUtilizador)
        {
            return await _dbSet
                .Where(c => c.IdUtilizador == idUtilizador)
                .Include(c => c.ConjuntosRoupas)
                .ToListAsync();
        }
    }
}
