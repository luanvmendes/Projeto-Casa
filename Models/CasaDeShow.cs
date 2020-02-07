using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Models
{
    public class CasaDeShow
    {
        [Required]
        public int Id { get; set; }   
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [MinLength(3, ErrorMessage = "Nome precisa conter ao menos 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo não pode estar em branco")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
    }
}