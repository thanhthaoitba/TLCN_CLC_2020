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
    public class MediaActorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public MediaActorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/MediaActor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaActor>>> GetMediaActor()
        {
            return await _context.MediaActor.ToListAsync();
        }

        // GET: api/MediaActor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaActor>> GetMediaActor(string id)
        {
            var mediaActor = await _context.MediaActor.FindAsync(id);

            if (mediaActor == null)
            {
                return NotFound();
            }

            return mediaActor;
        }
         [HttpGet("{GetListMediaActorByActorId}/{id}")]
        public async Task<ActionResult<IEnumerable<MediaActor>>> GetListMediaActorByActorId(string id)
        {
            var mediaActor = await _context.MediaActor.Where(use => use.ActorId == id).ToListAsync();

            if (mediaActor == null)
            {
                return NotFound();
            }

            return mediaActor;
        }

        // PUT: api/MediaActor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaActor(string id, MediaActor mediaActor)
        {
            if (id != mediaActor.MediaActorId)
            {
                return BadRequest();
            }

            _context.Entry(mediaActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaActorExists(id))
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

        // POST: api/MediaActor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MediaActor>> PostMediaActor(MediaActor mediaActor)
        {
            _context.MediaActor.Add(mediaActor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MediaActorExists(mediaActor.MediaActorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediaActor", new { id = mediaActor.MediaActorId }, mediaActor);
        }

        // DELETE: api/MediaActor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediaActor>> DeleteMediaActor(string id)
        {
            var mediaActor = await _context.MediaActor.FindAsync(id);
            if (mediaActor == null)
            {
                return NotFound();
            }

            _context.MediaActor.Remove(mediaActor);
            await _context.SaveChangesAsync();

            return mediaActor;
        }

        private bool MediaActorExists(string id)
        {
            return _context.MediaActor.Any(e => e.MediaActorId == id);
        }
    }
}
