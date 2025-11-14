using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using StyleMateAPI.Models;
using StyleMateAPI.Services;

namespace StyleMateAPI.Controllers
=======
using StyleMate1._1.Models;
using StyleMate1._1.Services;

namespace StyleMate1._1.Controllers
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly EventoService _service;

        public EventosController(EventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetAll()
        {
            var eventos = await _service.GetAllAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            var evento = await _service.GetByIdAsync(id);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        [HttpGet("byUser/{idUtilizador}")]
        public async Task<ActionResult<IEnumerable<Evento>>> GetByUser(int idUtilizador)
        {
            var eventos = await _service.GetByUserAsync(idUtilizador);
            return Ok(eventos);
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> Create(Evento evento)
        {
            var created = await _service.CreateAsync(evento);
            return CreatedAtAction(nameof(Get), new { id = created.IdEvento }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evento evento)
        {
            if (id != evento.IdEvento) return BadRequest();
            await _service.UpdateAsync(evento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
