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
    public class MalasController : ControllerBase
    {
        private readonly MalaService _service;

        public MalasController(MalaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mala>>> GetAll()
        {
            var malas = await _service.GetAllAsync();
            return Ok(malas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mala>> Get(int id)
        {
            var mala = await _service.GetByIdAsync(id);
            if (mala == null) return NotFound();
            return Ok(mala);
        }

        [HttpGet("byUser/{idUtilizador}")]
        public async Task<ActionResult<IEnumerable<Mala>>> GetByUser(int idUtilizador)
        {
            var malas = await _service.GetByUserAsync(idUtilizador);
            return Ok(malas);
        }

        [HttpPost]
        public async Task<ActionResult<Mala>> Create(Mala mala)
        {
            var created = await _service.CreateAsync(mala);
            return CreatedAtAction(nameof(Get), new { id = created.IdMala }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Mala mala)
        {
            if (id != mala.IdMala) return BadRequest();
            await _service.UpdateAsync(mala);
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
