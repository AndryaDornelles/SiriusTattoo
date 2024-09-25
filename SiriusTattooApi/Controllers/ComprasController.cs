using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ComprasRepository _comprasRepository;

        public ComprasController(IConfiguration configuration)
        {
            _comprasRepository = new ComprasRepository(configuration);
        }

        [HttpGet("Listar")]
        public IActionResult BuscarTodas()
        {
            try
            {
                var lista = _comprasRepository.BuscarTodas();
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
                var lista = _comprasRepository.BuscarPorTatuador(Id);
                return Ok(lista);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Cliente/{Id}")]
        public IActionResult BuscarPorCliente(long Id)
        {
            try
            {
                var lista = _comprasRepository.BuscarPorCliente(Id);
                return Ok(lista);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Comprar")]
        public async Task<IActionResult> Register(ComprasRequest comprasRequest)
        {
            if (comprasRequest == null)
            {
                return BadRequest("Os campos são obrigatórios");
            }
            try
            {
                var id = await _comprasRepository.CadastrarCompra(comprasRequest);
                return Ok(id);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
