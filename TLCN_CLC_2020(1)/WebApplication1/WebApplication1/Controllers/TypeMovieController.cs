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
    public class TypeMovieController : ControllerBase
    {
        private readonly APIDbContext _context;

        public TypeMovieController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeMovie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeMovie>>> GetTypeMovies()
        {
            return await _context.TypeMovies.ToListAsync();
        }

        // GET: api/TypeMovie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeMovie>> GetTypeMovie(string id)
        {
            var typeMovie = await _context.TypeMovies.FindAsync(id);

            if (typeMovie == null)
            {
                return NotFound();
            }

            return typeMovie;
        }

        // PUT: api/TypeMovie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeMovie(string id, TypeMovie typeMovie)
        {
            if (id != typeMovie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(typeMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeMovieExists(id))
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

        // POST: api/TypeMovie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeMovie>> PostTypeMovie(TypeMovie typeMovie)
        {
            _context.TypeMovies.Add(typeMovie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeMovieExists(typeMovie.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeMovie", new { id = typeMovie.MovieId }, typeMovie);
        }

        // DELETE: api/TypeMovie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeMovie>> DeleteTypeMovie(string id)
        {
            var typeMovie = await _context.TypeMovies.FindAsync(id);
            if (typeMovie == null)
            {
                return NotFound();
            }

            _context.TypeMovies.Remove(typeMovie);
            await _context.SaveChangesAsync();

            return typeMovie;
        }

        private bool TypeMovieExists(string id)
        {
            return _context.TypeMovies.Any(e => e.MovieId == id);
        }
    }
}
