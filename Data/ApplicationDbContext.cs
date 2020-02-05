using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Models;

namespace ProjetoTeste.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<CasaDeShow> CasaShow {get; set;}
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
