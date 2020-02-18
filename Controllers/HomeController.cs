using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasaShow.Models;
using CasaShow.Data;
using Microsoft.EntityFrameworkCore;

namespace CasaShow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = _context.Categorias.ToList();
            var casa = _context.CasaShow.ToList();
            return View(await _context.Eventos.OrderBy(data => data.Data).ToListAsync());
        }
    }
}