using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roupa.Data;
using Roupa.Models;

namespace Roupa.Controllers
{
    public class CadastroDeVendasController : Controller
    {
        private readonly Context _context;

        public CadastroDeVendasController(Context context)
        {
            _context = context;
        }

        // GET: CadastroDeVendas
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> Index()
        {
            var context = _context.CadastroDeVendas.Include(c => c.Cliente);
            return View(await context.ToListAsync());
        }

        // GET: CadastroDeVendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CadastroDeVendas == null)
            {
                return NotFound();
            }

            var cadastroDeVendas = await _context.CadastroDeVendas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.CadastroDeVendasId == id);
            if (cadastroDeVendas == null)
            {
                return NotFound();
            }

            return View(cadastroDeVendas);
        }

        // GET: CadastroDeVendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "ClienteId", "Nome");
            return View();
        }

        // POST: CadastroDeVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastroDeVendasId,NotaCompra,DataHora,ClienteId")] CadastroDeVendas cadastroDeVendas)
        {
            if (ModelState.IsValid)
            {
                cadastroDeVendas.CadastroDeVendasId = Guid.NewGuid();
                _context.Add(cadastroDeVendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "ClienteId", "Nome", cadastroDeVendas.ClienteId);
            return View(cadastroDeVendas);
        }

        // GET: CadastroDeVendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CadastroDeVendas == null)
            {
                return NotFound();
            }

            var cadastroDeVendas = await _context.CadastroDeVendas.FindAsync(id);
            if (cadastroDeVendas == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "ClienteId", "Nome", cadastroDeVendas.ClienteId);
            return View(cadastroDeVendas);
        }

        // POST: CadastroDeVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadastroDeVendasId,NotaCompra,DataHora,ClienteId")] CadastroDeVendas cadastroDeVendas)
        {
            if (id != cadastroDeVendas.CadastroDeVendasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroDeVendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroDeVendasExists(cadastroDeVendas.CadastroDeVendasId))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Cliente>(), "ClienteId", "Nome", cadastroDeVendas.ClienteId);
            return View(cadastroDeVendas);
        }

        // GET: CadastroDeVendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CadastroDeVendas == null)
            {
                return NotFound();
            }

            var cadastroDeVendas = await _context.CadastroDeVendas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.CadastroDeVendasId == id);
            if (cadastroDeVendas == null)
            {
                return NotFound();
            }

            return View(cadastroDeVendas);
        }

        // POST: CadastroDeVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CadastroDeVendas == null)
            {
                return Problem("Entity set 'Context.CadastroDeVendas'  is null.");
            }
            var cadastroDeVendas = await _context.CadastroDeVendas.FindAsync(id);
            if (cadastroDeVendas != null)
            {
                _context.CadastroDeVendas.Remove(cadastroDeVendas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroDeVendasExists(Guid id)
        {
          return (_context.CadastroDeVendas?.Any(e => e.CadastroDeVendasId == id)).GetValueOrDefault();
        }


        [HttpPost]
        public async Task<IActionResult> FilterVenda(string inFiltro)
        {
            if (inFiltro != null)
            {
                string pesquisa = inFiltro.Trim().ToLower();
                var context = _context.CadastroDeVendas.Where(p => p.NotaVenda.ToString() == pesquisa).Include(c => c.Cliente);
                return View("Index", context);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
