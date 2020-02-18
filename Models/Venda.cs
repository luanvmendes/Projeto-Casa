using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CasaShow.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public DateTime Data { get; set; }
        public float Total { get; set; }
        
    }
}