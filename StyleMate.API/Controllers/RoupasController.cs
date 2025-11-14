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
    public class RoupasController : ControllerBase
    {
        private readonly RoupaService _service;

        public RoupasController(RoupaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roupa>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("byUser/{idUtilizador}")]
        public async Task<ActionResult<IEnumerable<Roupa>>> GetByUser(int idUtilizador)
        {
            var list = await _service.GetByUserAsync(idUtilizador);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roupa>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Roupa>> Create(Roupa r)
        {
            var created = await _service.CreateAsync(r);
            return CreatedAtAction(nameof(Get), new { id = created.IdRoupa }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Roupa r)
        {
            if (id != r.IdRoupa) return BadRequest();
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // update fields
            existing.Nome = r.Nome;
            existing.CategoriaIA = r.CategoriaIA;
            existing.CategoriaConfidence = r.CategoriaConfidence;
            existing.CorIA = r.CorIA;
            existing.EstacaoSugeridaIA = r.EstacaoSugeridaIA;
            existing.CategoriaUser = r.CategoriaUser;
            existing.CorUser = r.CorUser;
            existing.EstacaoUser = r.EstacaoUser;
            existing.Foto = r.Foto;
            existing.IdUtilizador = r.IdUtilizador;

            await _service.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
<<<<<<< HEAD
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromServices] AzureBlobService blobService)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum ficheiro enviado.");

            using var stream = file.OpenReadStream();

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string url = await blobService.UploadAsync(stream, fileName);

            return Ok(new { url });
        }

=======
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
    }
}
