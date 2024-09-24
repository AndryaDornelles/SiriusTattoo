﻿using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using LoginRequest = Api.Models.LoginRequest;


namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TatuadoresController : ControllerBase
    {
        private readonly TatuadoresRepository _tatuadoresRepository;

        public TatuadoresController(IConfiguration configuration)
        {
            _tatuadoresRepository = new TatuadoresRepository(configuration);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var lista = _tatuadoresRepository.BuscarTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            try
            {
                var tatuador = _tatuadoresRepository.AutenticarUser(request.Email, request.Password);

                if (tatuador == null)
                {
                    return Unauthorized("Usuário ou senha inválidos.");
                }
                return Ok(tatuador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("BuscarTatuador/{Id}")]
        public IActionResult BuscarPorId(long Id)
        {
            try
            {
                var lista = _tatuadoresRepository.BuscarPorId(Id);
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> Register([FromBody] TatuadoresModel tatuador)
        {
            if (tatuador == null)
            { 
                return BadRequest("Os campos são obrigatórios");
            }
            try
            {
                var id = await _tatuadoresRepository.CadastrarTatuador(tatuador);
                return CreatedAtAction(nameof(BuscarTodos), new {id}, tatuador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeletarTatuador/{id}")]
        public async Task<IActionResult> DeletarTatuador(long id)
        {
            try
            {
                // Busca o tatuador pelo ID
                var cliente = _tatuadoresRepository.BuscarPorId(id);

                // Verifica se o tatuador foi encontrado
                if (cliente == null)
                {
                    return NotFound("Tatuador não encontrado.");
                }

                // Chama o método do repositório para deletar o tatuador
                await _tatuadoresRepository.DeletarTatuadorPorId(id);

                // Retorna uma resposta de sucesso
                return NoContent(); // HTTP 204: Requisição foi bem sucedida, mas sem conteúdo no corpo
            }
            catch (Exception ex)
            {
                // Retorna uma resposta de erro com o status HTTP 500 (Erro Interno)
                return StatusCode(500, ex.Message);
            }
        }

    }
}
