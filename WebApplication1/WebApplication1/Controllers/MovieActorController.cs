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
    public class MovieActorController : ControllerBase
    {
        private readonly APIDbContext _context;

        public MovieActorController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieActor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActor>>> GetMovieActors()
        {
            return await _context.MovieActors.ToListAsync();
        }

        // GET: api/MovieActor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActor>> GetMovieActor(string id)
        {
            var movieActor = await _context.MovieActors.FindAsync(id);

            if (movieActor == null)
            {
                return NotFound();
            }

            return movieActor;
        }

        // PUT: api/MovieActor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActor(string id, MovieActor movieActor)
        {
            if (id != movieActor.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movieActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorExists(id))
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

        // POST: api/MovieActor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieActor>> PostMovieActor(MovieActor movieActor)
        {
            _context.MovieActors.Add(movieActor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieActorExists(movieActor.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieActor", new { id = movieActor.MovieId }, movieActor);
        }

        // DELETE: api/MovieActor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieActor>> DeleteMovieActor(string id)
        {
            var movieActor = await _context.MovieActors.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }

            _context.MovieActors.Remove(movieActor);
            await _context.SaveChangesAsync();

            return movieActor;
        }

        private bool MovieActorExists(string id)
        {
            return _context.MovieActors.Any(e => e.MovieId == id);
        }
    }
}
