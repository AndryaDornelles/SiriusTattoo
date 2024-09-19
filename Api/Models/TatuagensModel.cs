﻿namespace Api.Models
{
    public class TatuagensModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public TatuadoresModel Tatuadores { get; set; }
    }
}
