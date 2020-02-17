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
        [Required(ErrorMessage = "Data da venda é obrigatório")]
        public DateTime Data { get; set; }
        [Required]
        public float Total { get; set; }
    }
}