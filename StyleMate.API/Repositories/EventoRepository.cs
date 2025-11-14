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
    public class EventoRepository
    {
        private readonly StyleMateContext _context;

        public EventoRepository(StyleMateContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> GetAllAsync() =>
            await _context.Eventos.Include(e => e.Utilizador).ToListAsync();

        public async Task<Evento?> GetByIdAsync(int id) =>
            await _context.Eventos.Include(e => e.Utilizador)
                                  .FirstOrDefaultAsync(e => e.IdEvento == id);

        public async Task<List<Evento>> GetByUserAsync(int idUtilizador) =>
            await _context.Eventos.Where(e => e.IdUtilizador == idUtilizador).ToListAsync();

        public async Task<Evento> AddAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
