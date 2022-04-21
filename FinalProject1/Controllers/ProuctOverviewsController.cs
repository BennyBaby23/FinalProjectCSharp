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
    public class ProuctOverviewsController : Controller
    {
        private readonly DataContext _context;

        public ProuctOverviewsController(DataContext context)
        {
            _context = context;
        }

        // GET: ProuctOverviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProuctOverview.ToListAsync());
        }

        // GET: ProuctOverviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouctOverview = await _context.ProuctOverview
                .FirstOrDefaultAsync(m => m.ProductoverviewID == id);
            if (prouctOverview == null)
            {
                return NotFound();
            }

            return View(prouctOverview);
        }

        // GET: ProuctOverviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProuctOverviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoverviewID,ProductSize,ProductParts,ProductReview")] ProuctOverview prouctOverview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prouctOverview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prouctOverview);
        }

        // GET: ProuctOverviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouctOverview = await _context.ProuctOverview.FindAsync(id);
            if (prouctOverview == null)
            {
                return NotFound();
            }
            return View(prouctOverview);
        }

        // POST: ProuctOverviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoverviewID,ProductSize,ProductParts,ProductReview")] ProuctOverview prouctOverview)
        {
            if (id != prouctOverview.ProductoverviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prouctOverview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProuctOverviewExists(prouctOverview.ProductoverviewID))
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
            return View(prouctOverview);
        }

        // GET: ProuctOverviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prouctOverview = await _context.ProuctOverview
                .FirstOrDefaultAsync(m => m.ProductoverviewID == id);
            if (prouctOverview == null)
            {
                return NotFound();
            }

            return View(prouctOverview);
        }

        // POST: ProuctOverviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prouctOverview = await _context.ProuctOverview.FindAsync(id);
            _context.ProuctOverview.Remove(prouctOverview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProuctOverviewExists(int id)
        {
            return _context.ProuctOverview.Any(e => e.ProductoverviewID == id);
        }
    }
}
