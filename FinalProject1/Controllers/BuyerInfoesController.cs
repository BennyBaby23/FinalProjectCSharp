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
    [Authorize]
    public class BuyerInfoesController : Controller
    {
        private readonly DataContext _context;

        public BuyerInfoesController(DataContext context)
        {
            _context = context;
        }

        // GET: BuyerInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuyerInfo.ToListAsync());
        }

        // GET: BuyerInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyerInfo = await _context.BuyerInfo
                .FirstOrDefaultAsync(m => m.BuyerID == id);
            if (buyerInfo == null)
            {
                return NotFound();
            }

            return View(buyerInfo);
        }

        // GET: BuyerInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuyerInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuyerID,BuyerName,BuyerAge,BuyerAddress")] BuyerInfo buyerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyerInfo);
        }

        // GET: BuyerInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyerInfo = await _context.BuyerInfo.FindAsync(id);
            if (buyerInfo == null)
            {
                return NotFound();
            }
            return View(buyerInfo);
        }

        // POST: BuyerInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuyerID,BuyerName,BuyerAge,BuyerAddress")] BuyerInfo buyerInfo)
        {
            if (id != buyerInfo.BuyerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerInfoExists(buyerInfo.BuyerID))
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
            return View(buyerInfo);
        }

        // GET: BuyerInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyerInfo = await _context.BuyerInfo
                .FirstOrDefaultAsync(m => m.BuyerID == id);
            if (buyerInfo == null)
            {
                return NotFound();
            }

            return View(buyerInfo);
        }

        // POST: BuyerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyerInfo = await _context.BuyerInfo.FindAsync(id);
            _context.BuyerInfo.Remove(buyerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerInfoExists(int id)
        {
            return _context.BuyerInfo.Any(e => e.BuyerID == id);
        }
    }
}
