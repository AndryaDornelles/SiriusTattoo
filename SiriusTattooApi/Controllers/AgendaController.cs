using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaRepository _agendaRepository;

        public AgendaController(IConfiguration configuration)
        {
            _agendaRepository = new AgendaRepository(configuration);
        }

        [HttpGet("Listar")]
        public IActionResult BuscarToda()
        {
            try
            {
                var lista = _agendaRepository.BuscarToda();
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
                var lista = _agendaRepository.BuscarPorCliente(Id);
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
                var lista = _agendaRepository.BuscarPorCliente(Id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Agendar")]
        public async Task<IActionResult> Register(AgendaRequest agendaRequest)
        {
            if (agendaRequest == null)
            {
                return BadRequest("Os campos são obrigatórios");
            }
            try
            {
                var id = await _agendaRepository.CadastrarAgenda(agendaRequest);
                return Ok(id);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }

    }
}
