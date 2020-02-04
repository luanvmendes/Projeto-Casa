using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public DateTime Data { get; set; }
        [Display(Name = "Preço do Ingresso")]
        public float ValorIngresso { get; set; }
        public virtual CasaDeShow CasaShow { get; set; }
        public virtual Categoria Categ { get; set; }
    }
}