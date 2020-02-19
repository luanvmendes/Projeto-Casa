using System;
using System.Collections.Generic;
using System.Text;
using CasaShow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CasaShow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {  
        public DbSet<CasaDeShow> CasaShow {get; set;}
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ListaVenda> ListaVendas { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
