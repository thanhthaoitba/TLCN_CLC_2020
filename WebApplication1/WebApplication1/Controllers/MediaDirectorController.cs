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
    public class MediaDirectorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public MediaDirectorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/MediaDirector
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaDirector>>> GetMediaDirector()
        {
            return await _context.MediaDirector.ToListAsync();
        }

        // GET: api/MediaDirector/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaDirector>> GetMediaDirector(string id)
        {
            var mediaDirector = await _context.MediaDirector.FindAsync(id);

            if (mediaDirector == null)
            {
                return NotFound();
            }

            return mediaDirector;
        }
        [HttpGet("{GetlistMediaDirectorById}/{id}")]
        public async Task<ActionResult<IEnumerable<MediaDirector>>> GetlistMediaDirectorById(string id)
        {
            var mediaDirector = await _context.MediaDirector.Where(use=>use.DirectorsId==id).ToListAsync();

            if (mediaDirector == null)
            {
                return NotFound();
            }

            return mediaDirector;
        }

        // PUT: api/MediaDirector/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaDirector(string id, MediaDirector mediaDirector)
        {
            if (id != mediaDirector.MediaDirectorId)
            {
                return BadRequest();
            }

            _context.Entry(mediaDirector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaDirectorExists(id))
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

        // POST: api/MediaDirector
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MediaDirector>> PostMediaDirector(MediaDirector mediaDirector)
        {
            _context.MediaDirector.Add(mediaDirector);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MediaDirectorExists(mediaDirector.MediaDirectorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediaDirector", new { id = mediaDirector.MediaDirectorId }, mediaDirector);
        }

        // DELETE: api/MediaDirector/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediaDirector>> DeleteMediaDirector(string id)
        {
            var mediaDirector = await _context.MediaDirector.FindAsync(id);
            if (mediaDirector == null)
            {
                return NotFound();
            }

            _context.MediaDirector.Remove(mediaDirector);
            await _context.SaveChangesAsync();

            return mediaDirector;
        }

        private bool MediaDirectorExists(string id)
        {
            return _context.MediaDirector.Any(e => e.MediaDirectorId == id);
        }
    }
}
