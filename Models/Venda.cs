using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public DateTime Data { get; set; }
        public List<ListaVenda> Lista { get; set; }
        public float Total { get; set; }
        
    }
}