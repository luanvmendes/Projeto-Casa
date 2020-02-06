using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Models
{
    public class Evento
    {
        public int Id { get; set; }
        [Display(Name = "Show")]
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Data { get; set; }
        [Display(Name = "Preço do Ingresso")]
        [DisplayFormat(DataFormatString = "R$ {0:N2}")]
        public float ValorIngresso { get; set; }
        [Display(Name = "Local")]
        public CasaDeShow CasaShow { get; set; }
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
    }
}