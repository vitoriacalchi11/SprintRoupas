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
    public class CadastroDeComprasController : Controller
    {
        private readonly Context _context;

        public CadastroDeComprasController(Context context)
        {
            _context = context;
        }

        // GET: CadastroDeCompras
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> Index()
        {
            var context = _context.CadastroDeCompras.Include(c => c.Fornecedor);
            return View(await context.ToListAsync());
        }

        // GET: CadastroDeCompras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CadastroDeCompras == null)
            {
                return NotFound();
            }

            var cadastroDeCompras = await _context.CadastroDeCompras
                .Include(c => c.Fornecedor)
                .FirstOrDefaultAsync(m => m.CadastroDeComprasId == id);
            if (cadastroDeCompras == null)
            {
                return NotFound();
            }

            return View(cadastroDeCompras);
        }

        // GET: CadastroDeCompras/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome");
            return View();
        }

        // POST: CadastroDeCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastroDeComprasId,NotaCompra,DataHora,FornecedorId")] CadastroDeCompras cadastroDeCompras)
        {
            if (ModelState.IsValid)
            {
                cadastroDeCompras.CadastroDeComprasId = Guid.NewGuid();
                _context.Add(cadastroDeCompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome", cadastroDeCompras.FornecedorId);
            return View(cadastroDeCompras);
        }

        // GET: CadastroDeCompras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CadastroDeCompras == null)
            {
                return NotFound();
            }

            var cadastroDeCompras = await _context.CadastroDeCompras.FindAsync(id);
            if (cadastroDeCompras == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome", cadastroDeCompras.FornecedorId);
            return View(cadastroDeCompras);
        }

        // POST: CadastroDeCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadastroDeComprasId,NotaCompra,DataHora,FornecedorId")] CadastroDeCompras cadastroDeCompras)
        {
            if (id != cadastroDeCompras.CadastroDeComprasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroDeCompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroDeComprasExists(cadastroDeCompras.CadastroDeComprasId))
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
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "Nome", cadastroDeCompras.FornecedorId);
            return View(cadastroDeCompras);
        }

        // GET: CadastroDeCompras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CadastroDeCompras == null)
            {
                return NotFound();
            }

            var cadastroDeCompras = await _context.CadastroDeCompras
                .Include(c => c.Fornecedor)
                .FirstOrDefaultAsync(m => m.CadastroDeComprasId == id);
            if (cadastroDeCompras == null)
            {
                return NotFound();
            }

            return View(cadastroDeCompras);
        }

        // POST: CadastroDeCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CadastroDeCompras == null)
            {
                return Problem("Entity set 'Context.CadastroDeCompras'  is null.");
            }
            var cadastroDeCompras = await _context.CadastroDeCompras.FindAsync(id);
            if (cadastroDeCompras != null)
            {
                _context.CadastroDeCompras.Remove(cadastroDeCompras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroDeComprasExists(Guid id)
        {
          return (_context.CadastroDeCompras?.Any(e => e.CadastroDeComprasId == id)).GetValueOrDefault();
        }


        [HttpPost]
        public async Task<IActionResult> FilterNota(string inFiltro)
        {
            if (inFiltro != null)
            {
                string pesquisa = inFiltro.Trim().ToLower();
                var context = _context.CadastroDeCompras.Where(p => p.NotaCompra.ToString() == pesquisa).Include(c => c.Fornecedor);
                return View("Index", context);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
