using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }
    }
}