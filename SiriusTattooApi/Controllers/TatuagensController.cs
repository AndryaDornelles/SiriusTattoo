using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TatuagensController : ControllerBase
    {
        private readonly TatuagensRepository _tatuagensRepository;

        public TatuagensController(IConfiguration configuration)
        {
            _tatuagensRepository = new TatuagensRepository(configuration);
        }
        [HttpGet("Listar")]
        public IActionResult BuscarTodas()
        {
            try
            {
                var lista = _tatuagensRepository.BuscarTodas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Tatuador/{Id}")]
        public IActionResult BuscarPorTatuador(long Id)
        {
            try
            {
                var lista = _tatuagensRepository.BuscarPorTatuador(Id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Register([FromBody] TatuagensModel tatuagem)
        {
            if (tatuagem == null)
            {
                return BadRequest("Os campos são obrigatórios");
            }
            try
            {
                var id = await _tatuagensRepository.CadastrarTatuagem(tatuagem);
                return CreatedAtAction(nameof(BuscarTodas), new { id }, tatuagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
