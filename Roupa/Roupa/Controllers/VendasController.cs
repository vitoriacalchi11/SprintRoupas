﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roupa.Data;
using Roupa.Models;

namespace Roupa.Controllers
{
    public class VendasController : Controller
    {
        private readonly Context _context;

        public VendasController(Context context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var context = _context.Venda.Include(v => v.CadastroDeVendas).Include(v => v.Produto);
            return View(await context.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.CadastroDeVendas)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["CadastroDeVendasId"] = new SelectList(_context.CadastroDeVendas, "CadastroDeVendasId", "NotaVenda");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,CadastroDeVendasId,Quantidade,ProdutoId,PrecoUnitario")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                venda.VendaId = Guid.NewGuid();
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroDeVendasId"] = new SelectList(_context.CadastroDeVendas, "CadastroDeVendasId", "NotaVenda", venda.CadastroDeVendasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["CadastroDeVendasId"] = new SelectList(_context.CadastroDeVendas, "CadastroDeVendasId", "NotaVenda", venda.CadastroDeVendasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VendaId,CadastroDeVendasId,Quantidade,ProdutoId,PrecoUnitario")] Venda venda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
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
            ViewData["CadastroDeVendasId"] = new SelectList(_context.CadastroDeVendas, "CadastroDeVendasId", "NotaVenda", venda.CadastroDeVendasId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", venda.ProdutoId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.CadastroDeVendas)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Venda == null)
            {
                return Problem("Entity set 'Context.Venda'  is null.");
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(Guid id)
        {
          return (_context.Venda?.Any(e => e.VendaId == id)).GetValueOrDefault();
        }
    }
}
