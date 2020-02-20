using System.ComponentModel.DataAnnotations;

namespace CasaShow.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public Evento Evento { get; set; }
        public int Quantidade { get; set; }
        [Display(Name = "Valor")]
        public float Preco { get; set; }
    }
}