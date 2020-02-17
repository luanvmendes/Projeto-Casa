using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaShow.Data;
using CasaShow.Models;

namespace CasaShow.Controllers
{
    public class CasaDeShowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasaDeShowController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("casadeshow")]
        // GET: CasaDeShow
        public async Task<IActionResult> Index()
        {
            //var count = _context.CasaShow.Count();
            //if (count != 0) {
                return View(await _context.CasaShow.ToListAsync());
            //} else {
            //    return Content("Não há casa de show cadastrada");
            //}
        }

        // GET: CasaDeShow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasaDeShow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco")] CasaDeShow casaDeShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casaDeShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casaDeShow);
        }

        // GET: CasaDeShow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaShow.FindAsync(id);
            if (casaDeShow == null)
            {
                return NotFound();
            }
            return View(casaDeShow);
        }

        // POST: CasaDeShow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco")] CasaDeShow casaDeShow)
        {
            if (id != casaDeShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casaDeShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaDeShowExists(casaDeShow.Id))
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
            return View(casaDeShow);
        }

        // GET: CasaDeShow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaDeShow = await _context.CasaShow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casaDeShow == null)
            {
                return NotFound();
            }

            return View(casaDeShow);
        }

        // POST: CasaDeShow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casaDeShow = await _context.CasaShow.FindAsync(id);
            _context.CasaShow.Remove(casaDeShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaDeShowExists(int id)
        {
            return _context.CasaShow.Any(e => e.Id == id);
        }
    }
}
