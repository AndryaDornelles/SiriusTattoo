﻿using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol.Core.Types;
using LoginRequest = Api.Models.LoginRequest;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesRepository _clientesRepository;

        public ClientesController(IConfiguration configuration)
        {
            _clientesRepository = new ClientesRepository(configuration);
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var lista = _clientesRepository.BuscarTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("BuscarCliente/{Id}")]
        public IActionResult BuscarPorId(long Id)
        {
            try
            {
                var lista = _clientesRepository.BuscarPorId(Id);
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            try
            {
                var cliente = _clientesRepository.AutenticarUser(request.Email, request.Password);

                if (cliente == null)
                {
                    return Unauthorized("Usuário ou senha inválidos.");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Cadastro")]
        public async Task<IActionResult> Register([FromBody] ClientesModel cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            try
            {
                var id = await _clientesRepository.CadastrarCliente(cliente);
                return CreatedAtAction(nameof(BuscarTodos), new { id }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DeletarCliente/{id}")]
        public async Task<IActionResult> DeletarCliente(long id)
        {
            try
            {
                // Busca o cliente pelo ID
                var cliente = _clientesRepository.BuscarPorId(id);

                // Verifica se o cliente foi encontrado
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado.");
                }

                // Chama o método do repositório para deletar o cliente
                await _clientesRepository.DeletarClientePorId(id);

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

