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
    public class PaymentInfoesController : Controller
    {
        private readonly DataContext _context;

        public PaymentInfoesController(DataContext context)
        {
            _context = context;
        }

        // GET: PaymentInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentInfo.ToListAsync());
        }

        // GET: PaymentInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentInfo = await _context.PaymentInfo
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (paymentInfo == null)
            {
                return NotFound();
            }

            return View(paymentInfo);
        }

        // GET: PaymentInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,PaymentMethod,BankName,CardNumer")] PaymentInfo paymentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentInfo);
        }

        // GET: PaymentInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentInfo = await _context.PaymentInfo.FindAsync(id);
            if (paymentInfo == null)
            {
                return NotFound();
            }
            return View(paymentInfo);
        }

        // POST: PaymentInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,PaymentMethod,BankName,CardNumer")] PaymentInfo paymentInfo)
        {
            if (id != paymentInfo.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentInfoExists(paymentInfo.PaymentID))
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
            return View(paymentInfo);
        }

        // GET: PaymentInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentInfo = await _context.PaymentInfo
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (paymentInfo == null)
            {
                return NotFound();
            }

            return View(paymentInfo);
        }

        // POST: PaymentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentInfo = await _context.PaymentInfo.FindAsync(id);
            _context.PaymentInfo.Remove(paymentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentInfoExists(int id)
        {
            return _context.PaymentInfo.Any(e => e.PaymentID == id);
        }
    }
}
