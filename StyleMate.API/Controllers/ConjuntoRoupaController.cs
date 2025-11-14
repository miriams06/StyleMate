using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using StyleMateAPI.Services;
using StyleMateAPI.Models;

namespace StyleMateAPI.Controllers
=======
using StyleMate1._1.Models;
using StyleMate1._1.Services;

namespace StyleMate1._1.Controllers
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConjuntoRoupaController : ControllerBase
    {
        private readonly ConjuntoRoupaService _service;

        public ConjuntoRoupaController(ConjuntoRoupaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConjuntoRoupa cr)
        {
            await _service.AddAsync(cr);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] int idConjunto, [FromQuery] int idRoupa)
        {
            await _service.RemoveAsync(idConjunto, idRoupa);
            return NoContent();
        }

        [HttpGet("roupas/{idConjunto}")]
        public async Task<ActionResult<IEnumerable<Roupa>>> GetRoupasDoConjunto(int idConjunto)
        {
            var roupas = await _service.GetRoupasDoConjuntoAsync(idConjunto);
            return Ok(roupas);
        }

        [HttpGet("conjuntos-da-roupa/{idRoupa}")]
        public async Task<ActionResult<IEnumerable<Conjunto>>> GetConjuntosDaRoupa(int idRoupa)
        {
            var conjuntos = await _service.GetConjuntosDaRoupaAsync(idRoupa);
            return Ok(conjuntos);
        }
    }
}
