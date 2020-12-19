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
    public class PhotoActorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public PhotoActorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/PhotoActor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoActor>>> GetPhotoActor()
        {
            return await _context.PhotoActor.ToListAsync();
        }

        // GET: api/PhotoActor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoActor>> GetPhotoActor(string id)
        {
            var photoActor = await _context.PhotoActor.FindAsync(id);

            if (photoActor == null)
            {
                return NotFound();
            }

            return photoActor;
        }
        [HttpGet("{GetListPhotoActorByActorId}/{id}")]
        public async Task<ActionResult<IEnumerable<PhotoActor>>> GetListPhotoActorByActorId(string id)
        {
            var photoActor = await _context.PhotoActor.Where   (use=>use.ActorId==id).ToListAsync();

            if (photoActor == null)
            {
                return NotFound();
            }

            return photoActor;
        }
        // PUT: api/PhotoActor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoActor(string id, PhotoActor photoActor)
        {
            if (id != photoActor.PhotoActorId)
            {
                return BadRequest();
            }

            _context.Entry(photoActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoActorExists(id))
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

        // POST: api/PhotoActor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhotoActor>> PostPhotoActor(PhotoActor photoActor)
        {
            _context.PhotoActor.Add(photoActor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhotoActorExists(photoActor.PhotoActorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhotoActor", new { id = photoActor.PhotoActorId }, photoActor);
        }

        // DELETE: api/PhotoActor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoActor>> DeletePhotoActor(string id)
        {
            var photoActor = await _context.PhotoActor.FindAsync(id);
            if (photoActor == null)
            {
                return NotFound();
            }

            _context.PhotoActor.Remove(photoActor);
            await _context.SaveChangesAsync();

            return photoActor;
        }

        private bool PhotoActorExists(string id)
        {
            return _context.PhotoActor.Any(e => e.PhotoActorId == id);
        }
    }
}
