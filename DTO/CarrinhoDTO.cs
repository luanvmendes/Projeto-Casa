using System.ComponentModel.DataAnnotations;
using CasaShow.Models;

namespace CasaShow.DTO
{
    public class CarrinhoDTO
    {
        public int Id { get; set; }
        [Display(Name = "Show")]
        public int EventoId { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Preço Unitário")]
        public float Preco { get; set; }
    }
}