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
    public class PrizeController : ControllerBase
    {
        private readonly APIDbContext _context;

        public PrizeController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Prize
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prize>>> GetPrizes()
        {
            return await _context.Prizes.ToListAsync();
        }

        // GET: api/Prize/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prize>> GetPrize(string id)
        {
            var prize = await _context.Prizes.FindAsync(id);

            if (prize == null)
            {
                return NotFound();
            }

            return prize;
        }

        // PUT: api/Prize/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrize(string id, Prize prize)
        {
            if (id != prize.PrizeId)
            {
                return BadRequest();
            }

            _context.Entry(prize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrizeExists(id))
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

        // POST: api/Prize
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prize>> PostPrize(Prize prize)
        {
            _context.Prizes.Add(prize);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrizeExists(prize.PrizeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrize", new { id = prize.PrizeId }, prize);
        }

        // DELETE: api/Prize/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prize>> DeletePrize(string id)
        {
            var prize = await _context.Prizes.FindAsync(id);
            if (prize == null)
            {
                return NotFound();
            }

            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();

            return prize;
        }

        private bool PrizeExists(string id)
        {
            return _context.Prizes.Any(e => e.PrizeId == id);
        }
    }
}
