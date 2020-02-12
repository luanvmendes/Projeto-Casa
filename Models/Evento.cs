using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Models
{
    public class Evento
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Show")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Lotação")]
        public int Capacidade { get; set; }
        [Required(ErrorMessage = "Data não pode estar em branco")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Preço do Ingresso")]
        [DisplayFormat(DataFormatString = "R$ {0:N2}")]
        public float ValorIngresso { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Local")]
        public CasaDeShow CasaShow { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
        public string Imagem { get; set; }
    }
}