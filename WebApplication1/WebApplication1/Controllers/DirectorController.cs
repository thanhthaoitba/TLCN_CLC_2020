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
    public class DirectorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public DirectorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Director
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Directors>>> GetDirectors()
        {
            return await _context.Directors.ToListAsync();
        }

        // GET: api/Director/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Directors>> GetDirectors(string id)
        {
            var directors = await _context.Directors.FindAsync(id);

            if (directors == null)
            {
                return NotFound();
            }

            return directors;
        }

        // PUT: api/Director/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectors(string id, Directors directors)
        {
            if (id != directors.DirectorsId)
            {
                return BadRequest();
            }

            _context.Entry(directors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorsExists(id))
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

        // POST: api/Director
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Directors>> PostDirectors(Directors directors)
        {
            _context.Directors.Add(directors);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DirectorsExists(directors.DirectorsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDirectors", new { id = directors.DirectorsId }, directors);
        }

        // DELETE: api/Director/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Directors>> DeleteDirectors(string id)
        {
            var directors = await _context.Directors.FindAsync(id);
            if (directors == null)
            {
                return NotFound();
            }

            _context.Directors.Remove(directors);
            await _context.SaveChangesAsync();

            return directors;
        }

        private bool DirectorsExists(string id)
        {
            return _context.Directors.Any(e => e.DirectorsId == id);
        }
    }
}
