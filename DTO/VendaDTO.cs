using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CasaShow.DTO
{
    public class VendaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public IdentityUser UserId { get; set; }
        public DateTime Data { get; set; }
        public int EventoId { get; set; }
        public int Quantidade { get; set; }
        [Required]
        [Display(Name="Preço Unitário")]
        public float Total { get; set; }
    }
}