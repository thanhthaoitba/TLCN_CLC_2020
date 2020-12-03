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
    public class UserFavoriteMovieController : ControllerBase
    {
        private readonly APIDbContext _context;

        public UserFavoriteMovieController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/UserFavoriteMovie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFavoriteMovie>>> GetUserFavoriteMovies()
        {
            return await _context.UserFavoriteMovies.ToListAsync();
        }

        // GET: api/UserFavoriteMovie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFavoriteMovie>> GetUserFavoriteMovie(string id)
        {
            var userFavoriteMovie = await _context.UserFavoriteMovies.FindAsync(id);

            if (userFavoriteMovie == null)
            {
                return NotFound();
            }

            return userFavoriteMovie;
        }

        // PUT: api/UserFavoriteMovie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFavoriteMovie(string id, UserFavoriteMovie userFavoriteMovie)
        {
            if (id != userFavoriteMovie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(userFavoriteMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFavoriteMovieExists(id))
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

        // POST: api/UserFavoriteMovie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserFavoriteMovie>> PostUserFavoriteMovie(UserFavoriteMovie userFavoriteMovie)
        {
            _context.UserFavoriteMovies.Add(userFavoriteMovie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserFavoriteMovieExists(userFavoriteMovie.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserFavoriteMovie", new { id = userFavoriteMovie.MovieId }, userFavoriteMovie);
        }

        // DELETE: api/UserFavoriteMovie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserFavoriteMovie>> DeleteUserFavoriteMovie(string id)
        {
            var userFavoriteMovie = await _context.UserFavoriteMovies.FindAsync(id);
            if (userFavoriteMovie == null)
            {
                return NotFound();
            }

            _context.UserFavoriteMovies.Remove(userFavoriteMovie);
            await _context.SaveChangesAsync();

            return userFavoriteMovie;
        }

        private bool UserFavoriteMovieExists(string id)
        {
            return _context.UserFavoriteMovies.Any(e => e.MovieId == id);
        }
    }
}
