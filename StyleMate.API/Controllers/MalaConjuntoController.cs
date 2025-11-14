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
    public class MalaConjuntoController : ControllerBase
    {
        private readonly MalaConjuntoService _service;

        public MalaConjuntoController(MalaConjuntoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(MalaConjunto mc)
        {
            await _service.AddAsync(mc);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int idMala, [FromQuery] int idConjunto)
        {
            await _service.RemoveAsync(idMala, idConjunto);
            return NoContent();
        }

        [HttpGet("conjuntos-da-mala/{idMala}")]
        public async Task<ActionResult<IEnumerable<Conjunto>>> GetConjuntosDaMala(int idMala)
        {
            var conjuntos = await _service.GetConjuntosDaMalaAsync(idMala);
            return Ok(conjuntos);
        }

        [HttpGet("malas-do-conjunto/{idConjunto}")]
        public async Task<ActionResult<IEnumerable<Mala>>> GetMalasDoConjunto(int idConjunto)
        {
            var malas = await _service.GetMalasDoConjuntoAsync(idConjunto);
            return Ok(malas);
        }
    }
}
