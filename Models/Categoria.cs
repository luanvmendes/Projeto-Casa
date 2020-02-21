using System.ComponentModel.DataAnnotations;

namespace CasaShow.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Gênero")]
        public string Nome { get; set; }
    }
}