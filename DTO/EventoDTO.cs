using System;
using System.ComponentModel.DataAnnotations;
using ProjetoTeste.Models;

namespace ProjetoTeste.DTO
{
    public class EventoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [StringLength(50, ErrorMessage = "Categoria não pode exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "Categoria precisa ter ao menos 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a lotação do evento")]
        public int Capacidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Preço do Ingresso")]
        //[DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "R$ {0:N2}")]
        public float ValorIngresso { get; set; }
        [Required(ErrorMessage = "Selecione uma opção")]
        [Display(Name = "Local")]
        public int CasaShowId { get; set; }
        [Required(ErrorMessage = "Selecione uma opção")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        //public string Imagem { get; set; }
    }
}