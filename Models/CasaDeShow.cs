using System.ComponentModel.DataAnnotations;

namespace ProjetoTeste.Models
{
    public class CasaDeShow
    {
        public int Id { get; set; }   
        public string Nome { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
    }
}