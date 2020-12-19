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
    public class UserBlogController : ControllerBase
    {
        private readonly APIDbContext _context;

        public UserBlogController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/UserBlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBlog>>> GetUserBlogs()
        {
            return await _context.UserBlogs.ToListAsync();
        }

        // GET: api/UserBlog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBlog>> GetUserBlog(string id)
        {
            var userBlog = await _context.UserBlogs.FindAsync(id);

            if (userBlog == null)
            {
                return NotFound();
            }

            return userBlog;
        }

        // PUT: api/UserBlog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBlog(string id, UserBlog userBlog)
        {
            if (id != userBlog.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(userBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBlogExists(id))
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

        // POST: api/UserBlog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserBlog>> PostUserBlog(UserBlog userBlog)
        {
            _context.UserBlogs.Add(userBlog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserBlogExists(userBlog.BlogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserBlog", new { id = userBlog.BlogId }, userBlog);
        }

        // DELETE: api/UserBlog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserBlog>> DeleteUserBlog(string id)
        {
            var userBlog = await _context.UserBlogs.FindAsync(id);
            if (userBlog == null)
            {
                return NotFound();
            }

            _context.UserBlogs.Remove(userBlog);
            await _context.SaveChangesAsync();

            return userBlog;
        }

        private bool UserBlogExists(string id)
        {
            return _context.UserBlogs.Any(e => e.BlogId == id);
        }
    }
}
