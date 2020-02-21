using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaShow.Data;
using CasaShow.DTO;
using CasaShow.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CasaShow.Controllers
{
    [Authorize]
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("vendas")]
        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var evento = _context.Eventos.ToList();
            return View(await _context.Vendas.Include(x => x.Evento).Where(x => x.User.Id == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync());
        }

        // GET: Vendas/Create
        public IActionResult Create(int? id)
        {
            var evento = _context.Eventos.First(x => x.Id == id);
            ViewBag.EventoId = evento.Id;
            ViewBag.EventoNome = evento.Nome;
            ViewBag.MaxQuantidade = evento.Capacidade;
            ViewBag.Preco = evento.ValorIngresso;
            ViewBag.Data = String.Format("{0:yyyy-MM-ddTHH:mm}", DateTime.Now);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,UserId,Data,Total,EventoId,Quantidade")] VendaDTO dtoVenda)
        {
            if (ModelState.IsValid)
            {
                var evento = _context.Eventos.First(x => x.Id == id);
                Venda venda = new Venda();
                dtoVenda.UserId.Id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                venda.User = _context.Users.First(user => user.Id == dtoVenda.UserId.Id);
                venda.Data = dtoVenda.Data;
                venda.Evento = evento;
                venda.Quantidade = dtoVenda.Quantidade;
                venda.Total = dtoVenda.Total * dtoVenda.Quantidade;
                evento.Capacidade -= venda.Quantidade;
                _context.Update(evento);
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dtoVenda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.Include(x => x.Evento).FirstOrDefaultAsync(x => x.Id == id);
            var evento = _context.Eventos.First(X => X.Id == venda.Evento.Id);
            evento.Capacidade += venda.Quantidade;
            _context.Update (evento);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
