using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject1.Models;

namespace FinalProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIAboutProducts1Controller : ControllerBase
    {
        private readonly DataContext _context;

        public APIAboutProducts1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/APIAboutProducts1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutProduct>>> GetFinalProject()
        {
            return await _context.FinalProject.ToListAsync();
        }

        // GET: api/APIAboutProducts1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutProduct>> GetAboutProduct(int id)
        {
            var aboutProduct = await _context.FinalProject.FindAsync(id);

            if (aboutProduct == null)
            {
                return NotFound();
            }

            return aboutProduct;
        }

        // PUT: api/APIAboutProducts1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAboutProduct(int id, AboutProduct aboutProduct)
        {
            if (id != aboutProduct.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(aboutProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIAboutProducts1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AboutProduct>> PostAboutProduct(AboutProduct aboutProduct)
        {
            _context.FinalProject.Add(aboutProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAboutProduct", new { id = aboutProduct.ProductID }, aboutProduct);
        }

        // DELETE: api/APIAboutProducts1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutProduct(int id)
        {
            var aboutProduct = await _context.FinalProject.FindAsync(id);
            if (aboutProduct == null)
            {
                return NotFound();
            }

            _context.FinalProject.Remove(aboutProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AboutProductExists(int id)
        {
            return _context.FinalProject.Any(e => e.ProductID == id);
        }
    }
}
