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
    public class ConjuntosController : ControllerBase
    {
        private readonly ConjuntoService _service;

        public ConjuntosController(ConjuntoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conjunto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("byUser/{idUtilizador}")]
        public async Task<ActionResult<IEnumerable<Conjunto>>> GetByUser(int idUtilizador)
        {
            var list = await _service.GetByUserAsync(idUtilizador);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conjunto>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Conjunto>> Create(Conjunto c)
        {
            var created = await _service.CreateAsync(c);
            return CreatedAtAction(nameof(Get), new { id = created.IdConjunto }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Conjunto c)
        {
            if (id != c.IdConjunto) return BadRequest();
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Nome = c.Nome;
            existing.Estilo = c.Estilo;
            existing.Estacao = c.Estacao;
            existing.Foto = c.Foto;
            existing.IdUtilizador = c.IdUtilizador;

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
