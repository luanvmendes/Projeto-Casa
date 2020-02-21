using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CasaShow.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Data da Compra")]
        public DateTime Data { get; set; }
        public Evento Evento { get; set; }
        public int Quantidade { get; set; }
        public float Total { get; set; }
        
    }
}