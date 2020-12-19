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
    public class PhotoDirectorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public PhotoDirectorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/PhotoDirector
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoDirector>>> GetPhotoDirector()
        {
            return await _context.PhotoDirector.ToListAsync();
        }

        // GET: api/PhotoDirector/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDirector>> GetPhotoDirector(string id)
        {
            var photoDirector = await _context.PhotoDirector.FindAsync(id);

            if (photoDirector == null)
            {
                return NotFound();
            }

            return photoDirector;
        }
        [HttpGet("{GetListPhotoDirectorByDirectorId}/{id}")]
        public async Task<ActionResult<IEnumerable<PhotoDirector>>> GetListPhotoDirectorByDirectorId(string id)
        {
            var photoDirector = await _context.PhotoDirector.Where(x => x.DirectorId==id).ToListAsync();

            if (photoDirector == null)
            {
                return NotFound();
            }

            return photoDirector;
        }


        // PUT: api/PhotoDirector/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoDirector(string id, PhotoDirector photoDirector)
        {
            if (id != photoDirector.PhotoProductorId)
            {
                return BadRequest();
            }

            _context.Entry(photoDirector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoDirectorExists(id))
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

        // POST: api/PhotoDirector
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhotoDirector>> PostPhotoDirector(PhotoDirector photoDirector)
        {
            _context.PhotoDirector.Add(photoDirector);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhotoDirectorExists(photoDirector.PhotoProductorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhotoDirector", new { id = photoDirector.PhotoProductorId }, photoDirector);
        }

        // DELETE: api/PhotoDirector/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhotoDirector>> DeletePhotoDirector(string id)
        {
            var photoDirector = await _context.PhotoDirector.FindAsync(id);
            if (photoDirector == null)
            {
                return NotFound();
            }

            _context.PhotoDirector.Remove(photoDirector);
            await _context.SaveChangesAsync();

            return photoDirector;
        }

        private bool PhotoDirectorExists(string id)
        {
            return _context.PhotoDirector.Any(e => e.PhotoProductorId == id);
        }
    }
}
