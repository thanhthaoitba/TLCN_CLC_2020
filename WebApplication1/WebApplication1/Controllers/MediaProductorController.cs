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
    public class MediaProductorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public MediaProductorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/MediaProductor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaProductor>>> GetMediaProductor()
        {
            return await _context.MediaProductor.ToListAsync();
        }

        // GET: api/MediaProductor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaProductor>> GetMediaProductor(string id)
        {
            var mediaProductor = await _context.MediaProductor.FindAsync(id);

            if (mediaProductor == null)
            {
                return NotFound();
            }

            return mediaProductor;
        }

        [HttpGet("{GetListMediaProductorByProductorId}/{id}")]
        public async Task<ActionResult<IEnumerable<MediaProductor>>> GetListMediaProductorByProductorId(string id)
        {
            var mediaProductor = await _context.MediaProductor.Where(x => x.ProductorId == id).ToListAsync();

            if (mediaProductor == null)
            {
                return NotFound();
            }

            return mediaProductor;
        }
        // PUT: api/MediaProductor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaProductor(string id, MediaProductor mediaProductor)
        {
            if (id != mediaProductor.MediaProductorId)
            {
                return BadRequest();
            }

            _context.Entry(mediaProductor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaProductorExists(id))
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

        // POST: api/MediaProductor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MediaProductor>> PostMediaProductor(MediaProductor mediaProductor)
        {
            _context.MediaProductor.Add(mediaProductor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MediaProductorExists(mediaProductor.MediaProductorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediaProductor", new { id = mediaProductor.MediaProductorId }, mediaProductor);
        }

        // DELETE: api/MediaProductor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediaProductor>> DeleteMediaProductor(string id)
        {
            var mediaProductor = await _context.MediaProductor.FindAsync(id);
            if (mediaProductor == null)
            {
                return NotFound();
            }

            _context.MediaProductor.Remove(mediaProductor);
            await _context.SaveChangesAsync();

            return mediaProductor;
        }

        private bool MediaProductorExists(string id)
        {
            return _context.MediaProductor.Any(e => e.MediaProductorId == id);
        }
    }
}
