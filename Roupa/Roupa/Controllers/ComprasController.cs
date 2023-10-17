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
    public class ComprasController : Controller
    {
        private readonly Context _context;

        public ComprasController(Context context)
        {
            _context = context;
        }

        // GET: Compras
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> Index()
        {
            var context = _context.Compra.Include(c => c.CadastroDeCompras).Include(c => c.Produto);
            return View(await context.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.CadastroDeCompras)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["CadastroDeComprasId"] = new SelectList(_context.CadastroDeCompras, "CadastroDeComprasId", "NotaCompra");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompraId,CadastroDeComprasId,Quantidade,ProdutoId,PrecoUnitario")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compra.CompraId = Guid.NewGuid();
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroDeComprasId"] = new SelectList(_context.CadastroDeCompras, "CadastroDeComprasId", "NotaCompra", compra.CadastroDeComprasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", compra.ProdutoId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["CadastroDeComprasId"] = new SelectList(_context.CadastroDeCompras, "CadastroDeComprasId", "NotaCompra", compra.CadastroDeComprasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", compra.ProdutoId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CompraId,CadastroDeComprasId,Quantidade,ProdutoId,PrecoUnitario")] Compra compra)
        {
            if (id != compra.CompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.CompraId))
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
            ViewData["CadastroDeComprasId"] = new SelectList(_context.CadastroDeCompras, "CadastroDeComprasId", "NotaCompra", compra.CadastroDeComprasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", compra.ProdutoId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.CadastroDeCompras)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Compra == null)
            {
                return Problem("Entity set 'Context.Compra'  is null.");
            }
            var compra = await _context.Compra.FindAsync(id);
            if (compra != null)
            {
                _context.Compra.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(Guid id)
        {
          return (_context.Compra?.Any(e => e.CompraId == id)).GetValueOrDefault();
        }
    }
}
