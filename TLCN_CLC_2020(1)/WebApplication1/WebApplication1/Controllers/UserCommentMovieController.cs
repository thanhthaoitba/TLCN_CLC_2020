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
    public class UserCommentMovieController : ControllerBase
    {
        private readonly APIDbContext _context;

        public UserCommentMovieController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCommentMovie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCommentMovie>>> GetUserCommentMovies()
        {
            return await _context.UserCommentMovies.ToListAsync();
        }

        // GET: api/UserCommentMovie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCommentMovie>> GetUserCommentMovie(string id)
        {
            var userCommentMovie = await _context.UserCommentMovies.FindAsync(id);

            if (userCommentMovie == null)
            {
                return NotFound();
            }

            return userCommentMovie;
        }

        // PUT: api/UserCommentMovie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCommentMovie(string id, UserCommentMovie userCommentMovie)
        {
            if (id != userCommentMovie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(userCommentMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCommentMovieExists(id))
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

        // POST: api/UserCommentMovie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserCommentMovie>> PostUserCommentMovie(UserCommentMovie userCommentMovie)
        {
            _context.UserCommentMovies.Add(userCommentMovie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCommentMovieExists(userCommentMovie.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCommentMovie", new { id = userCommentMovie.MovieId }, userCommentMovie);
        }

        // DELETE: api/UserCommentMovie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCommentMovie>> DeleteUserCommentMovie(string id)
        {
            var userCommentMovie = await _context.UserCommentMovies.FindAsync(id);
            if (userCommentMovie == null)
            {
                return NotFound();
            }

            _context.UserCommentMovies.Remove(userCommentMovie);
            await _context.SaveChangesAsync();

            return userCommentMovie;
        }

        private bool UserCommentMovieExists(string id)
        {
            return _context.UserCommentMovies.Any(e => e.MovieId == id);
        }
    }
}
