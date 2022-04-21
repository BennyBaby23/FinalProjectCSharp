using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;

namespace FinalProject1.Controllers
{
    public class ProuctSoresController : Controller
    {
        private readonly DataContext _context;

        public ProuctSoresController(DataContext context)
        {
            _context = context;
        }

        // GET: ProuctSores
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProuctSore.ToListAsync());
        }

        // GET: ProuctSores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouctSore = await _context.ProuctSore
                .FirstOrDefaultAsync(m => m.ProductStoreID == id);
            if (prouctSore == null)
            {
                return NotFound();
            }

            return View(prouctSore);
        }

        // GET: ProuctSores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProuctSores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductStoreID,StoreName,StoreAddress,StoreReview")] ProuctSore prouctSore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prouctSore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prouctSore);
        }

        // GET: ProuctSores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouctSore = await _context.ProuctSore.FindAsync(id);
            if (prouctSore == null)
            {
                return NotFound();
            }
            return View(prouctSore);
        }

        // POST: ProuctSores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductStoreID,StoreName,StoreAddress,StoreReview")] ProuctSore prouctSore)
        {
            if (id != prouctSore.ProductStoreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prouctSore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProuctSoreExists(prouctSore.ProductStoreID))
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
            return View(prouctSore);
        }

        // GET: ProuctSores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouctSore = await _context.ProuctSore
                .FirstOrDefaultAsync(m => m.ProductStoreID == id);
            if (prouctSore == null)
            {
                return NotFound();
            }

            return View(prouctSore);
        }

        // POST: ProuctSores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prouctSore = await _context.ProuctSore.FindAsync(id);
            _context.ProuctSore.Remove(prouctSore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProuctSoreExists(int id)
        {
            return _context.ProuctSore.Any(e => e.ProductStoreID == id);
        }
    }
}
