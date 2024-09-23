﻿using Api.Models;
using Api.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class TatuadoresRepository
    {
        private readonly DataContext _context;

        public TatuadoresRepository(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration.GetConnectionString("connection"));

            options.UseSqlServer();
            _context = new DataContext(options.Options);
        }

        // Método para autenticar tatuador
        public TatuadoresModel AutenticarUser(string email, string senha)
        {
            string hashedSenha = HashPassword(senha);

            var tatuador = _context.Tatuadores.FirstOrDefault(t => t.Email == email && t.Senha == hashedSenha);
            return tatuador;
        }

        private string HashPassword(string password)
        {
            // SHA-256 é uma função de hash criptográfico que gera um valor de 256 bits (32 bytes) a partir da entrada.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        public IEnumerable<TatuadoresModel> BuscarTodos()
        {
            return _context.Tatuadores;
        }
        public async Task<long> CadastrarTatuador(TatuadoresModel tatuador)
        {
            try
            {
                await _context.Tatuadores.AddAsync(tatuador);
                await _context.SaveChangesAsync();
                return tatuador.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar tatuador.", ex);
            }

        }
    }
}
