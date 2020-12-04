using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ProductorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Productor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productor>>> GetProductors()
        {
            return await _context.Productors.ToListAsync();
        }

        // GET: api/Productor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productor>> GetProductor(string id)
        {
            var productor = await _context.Productors.FindAsync(id);

            if (productor == null)
            {
                return NotFound();
            }

            return productor;
        }

        // PUT: api/Productor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductor(string id, Productor productor)
        {
            if (id != productor.ProductorId)
            {
                return BadRequest();
            }

            _context.Entry(productor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductorExists(id))
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

        // POST: api/Productor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Productor>> PostProductor(Productor productor)
        {
            _context.Productors.Add(productor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductorExists(productor.ProductorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductor", new { id = productor.ProductorId }, productor);
        }

        // DELETE: api/Productor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Productor>> DeleteProductor(string id)
        {
            var productor = await _context.Productors.FindAsync(id);
            if (productor == null)
            {
                return NotFound();
            }

            _context.Productors.Remove(productor);
            await _context.SaveChangesAsync();

            return productor;
        }

        private bool ProductorExists(string id)
        {
            return _context.Productors.Any(e => e.ProductorId == id);
        }
    }
}
