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
    public class RoupaRepository : GenericRepository<Roupa>
    {
        public RoupaRepository(StyleMateContext context) : base(context) { }

        public async Task<List<Roupa>> GetByUserAsync(int idUtilizador)
        {
            return await _dbSet.Where(r => r.IdUtilizador == idUtilizador).ToListAsync();
        }

        public async Task<List<Roupa>> FindByCategoriaIAAsync(string categoria)
        {
            return await _dbSet.Where(r => r.CategoriaIA == categoria).ToListAsync();
        }
    }
}
