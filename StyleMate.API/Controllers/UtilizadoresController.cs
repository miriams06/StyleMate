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
    public class UtilizadoresController : ControllerBase
    {
        private readonly UtilizadorService _service;

        public UtilizadoresController(UtilizadorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizador>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Utilizador>> Create(Utilizador u)
        {
            // No password handling here — external auth or other flow
            var created = await _service.CreateAsync(u);
            return CreatedAtAction(nameof(Get), new { id = created.IdUtilizador }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Utilizador u)
        {
            if (id != u.IdUtilizador) return BadRequest();
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // copy editable fields
            existing.Nome = u.Nome;
            existing.FotoPerfil = u.FotoPerfil;
            existing.Preferencias = u.Preferencias;
            existing.UltimoAcesso = u.UltimoAcesso;
            existing.Email = u.Email;
            existing.ExternalId = u.ExternalId;

            await _service.UpdateAsync(existing);
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
