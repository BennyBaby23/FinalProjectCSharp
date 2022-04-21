using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject1.Controllers
{
    [AllowAnonymous]
    public class AboutProductsController : Controller
    {
        private readonly DataContext _context;

        public AboutProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: AboutProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinalProject.ToListAsync());
        }

        // GET: AboutProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutProduct = await _context.FinalProject
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (aboutProduct == null)
            {
                return NotFound();
            }

            return View(aboutProduct);
        }

        // GET: AboutProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,AboutProducts,Productprice,ProductMadeCountry")] AboutProduct aboutProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutProduct);
        }

        // GET: AboutProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutProduct = await _context.FinalProject.FindAsync(id);
            if (aboutProduct == null)
            {
                return NotFound();
            }
            return View(aboutProduct);
        }

        // POST: AboutProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,AboutProducts,Productprice,ProductMadeCountry")] AboutProduct aboutProduct)
        {
            if (id != aboutProduct.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutProductExists(aboutProduct.ProductID))
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
            return View(aboutProduct);
        }

        // GET: AboutProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutProduct = await _context.FinalProject
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (aboutProduct == null)
            {
                return NotFound();
            }

            return View(aboutProduct);
        }

        // POST: AboutProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutProduct = await _context.FinalProject.FindAsync(id);
            _context.FinalProject.Remove(aboutProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutProductExists(int id)
        {
            return _context.FinalProject.Any(e => e.ProductID == id);
        }
    }
}
