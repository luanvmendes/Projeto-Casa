using System.ComponentModel.DataAnnotations;

namespace CasaShow.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }
    }
}