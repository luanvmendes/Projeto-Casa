using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaShow.Data;
using CasaShow.Models;
using CasaShow.DTO;

namespace CasaShow.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarrinhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carrinho
        public async Task<IActionResult> Index()
        {
            var evento = _context.Eventos.ToList();
            return View(await _context.Carrinho.ToListAsync());
        }

        // GET: Carrinho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // GET: Carrinho/Create
        public IActionResult Create(int? id)
        {
            var evento = _context.Eventos.First(x => x.Id == id);
            ViewBag.EventoId = evento.Id;
            ViewBag.EventoNome = evento.Nome;
            ViewBag.MaxQuantidade = evento.Capacidade;
            ViewBag.Preco = evento.ValorIngresso;
            return View();
        }

        // POST: Carrinho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,Quantidade,Preco")] CarrinhoDTO carrinhoTemp)
        {
            if (ModelState.IsValid)
            {
                var evento = _context.Eventos.First(x => x.Id == id);
                Carrinho carrinho = new Carrinho();
                carrinho.Evento = evento;
                carrinho.Quantidade = carrinhoTemp.Quantidade;
                carrinho.Preco = carrinhoTemp.Preco * carrinhoTemp.Quantidade;
                evento.Capacidade -= carrinho.Quantidade;
                _context.Update(evento);
                _context.Add(carrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Evento = _context.Eventos.ToList();
            return View(carrinhoTemp);
        }

        // GET: Carrinho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho.Include(e => e.Evento).SingleOrDefaultAsync(e => e.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            } else {
                CarrinhoDTO car = new CarrinhoDTO();
                car.Id = carrinho.Id;
                car.EventoId = carrinho.Evento.Id;
                car.Quantidade = carrinho.Quantidade;
                car.Preco = carrinho.Preco;
                ViewBag.Evento = _context.Eventos.ToList();
                return View(car);
            }
        }

        // POST: Carrinho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoId,Quantidade,Preco")] CarrinhoDTO carrinhoTemp)
        {
            if (id != carrinhoTemp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var car = _context.Carrinho.First(x => x.Id == carrinhoTemp.Id);
                    var evento = _context.Eventos.First(e => e.Id == carrinhoTemp.EventoId);
                    car.Id = carrinhoTemp.Id;
                    car.Evento = evento;
                    car.Quantidade = carrinhoTemp.Quantidade;
                    car.Preco = car.Quantidade * evento.ValorIngresso;
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(carrinhoTemp.Id))
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
            ViewBag.Evento = _context.Eventos.ToList();
            return View(carrinhoTemp);
        }

        // GET: Carrinho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // POST: Carrinho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrinho = await _context.Carrinho.FindAsync(id);
            _context.Carrinho.Remove(carrinho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoExists(int id)
        {
            return _context.Carrinho.Any(e => e.Id == id);
        }
    }
}
