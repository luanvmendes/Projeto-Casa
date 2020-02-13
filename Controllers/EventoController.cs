using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Data;
using ProjetoTeste.DTO;
using ProjetoTeste.Models;

namespace ProjetoTeste.Controllers
{
    public class EventoController : Controller
    {
        private IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;

        public EventoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        [HttpGet("eventos")]
        // GET: Evento
        public async Task<IActionResult> Index()
        {
            var categorias = _context.Categorias.ToList();
            var casa = _context.CasaShow.ToList();
            return View(await _context.Eventos.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            ViewBag.CasaShow = _context.CasaShow.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Capacidade,Data,ValorIngresso,CasaShowId,CategoriaId,Imagem")] EventoDTO eventoTemp, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "img");
                        var fileName = Path.GetRandomFileName();
                        var fileExtension = Path.GetExtension(formFile.FileName);

                        var fullPath = Path.Combine(filePath, fileName + fileExtension);

                        using (var stream = System.IO.File.Create(fullPath))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        eventoTemp.Imagem = "/img/" + fileName + fileExtension;
                    }
                }
                Evento evento = new Evento();
                evento.Nome = eventoTemp.Nome;
                evento.Capacidade = eventoTemp.Capacidade;
                evento.Data = eventoTemp.Data;
                evento.ValorIngresso = eventoTemp.ValorIngresso;
                evento.CasaShow = _context.CasaShow.First(cs => cs.Id == eventoTemp.CasaShowId);
                evento.Categoria = _context.Categorias.First(ctg => ctg.Id == eventoTemp.CategoriaId);
                evento.Imagem = eventoTemp.Imagem;
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CasaShow = _context.CasaShow.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(eventoTemp);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var evento = await _context.Eventos.Include(e => e.CasaShow).Include(e => e.Categoria).SingleOrDefaultAsync(e => e.Id == id);
            //var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            else {
                EventoDTO viewEvento = new EventoDTO();
                viewEvento.Id = evento.Id;
                viewEvento.Nome = evento.Nome;
                viewEvento.Capacidade = evento.Capacidade;
                viewEvento.Data = evento.Data;
                viewEvento.ValorIngresso = evento.ValorIngresso;
                viewEvento.CasaShowId = evento.CasaShow.Id;
                viewEvento.CategoriaId = evento.Categoria.Id;
                ViewBag.CasaShow = _context.CasaShow.ToList();
                ViewBag.Categorias = _context.Categorias.ToList();
                return View(viewEvento);
            }
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Capacidade,Data,ValorIngresso,CasaShowId,CategoriaId")] EventoDTO eventoTemp)
        {
            if (id != eventoTemp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var evento = _context.Eventos.First(e => e.Id == eventoTemp.Id);
                    evento.Nome = eventoTemp.Nome;
                    evento.Capacidade = eventoTemp.Capacidade;
                    evento.Data = eventoTemp.Data;
                    evento.ValorIngresso = eventoTemp.ValorIngresso;
                    evento.CasaShow = _context.CasaShow.First(cs => cs.Id == eventoTemp.CasaShowId);
                    evento.Categoria = _context.Categorias.First(ctg => ctg.Id == eventoTemp.CategoriaId);
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(eventoTemp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.CasaShow = _context.CasaShow.ToList();
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(eventoTemp);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
