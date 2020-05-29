using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_ValuateDataAccess.DataModels;

namespace E_ValuateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsDataController : ControllerBase
    {
        private readonly EvalContext _context;

        public PostsDataController(EvalContext context)
        {
            _context = context;
        }

        // GET: api/PostsData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostsData>>> GetPostsData()
        {
            return await _context.PostsData.ToListAsync();
        }

        // GET: api/PostsData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostsData>> GetPostsData(int id)
        {
            var postsData = await _context.PostsData.FindAsync(id);

            if (postsData == null)
            {
                return NotFound();
            }

            return postsData;
        }

        // PUT: api/PostsData/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostsData(int id, PostsData postsData)
        {
            if (id != postsData.PostId)
            {
                return BadRequest();
            }

            _context.Entry(postsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsDataExists(id))
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

        // POST: api/PostsData
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostsData>> PostPostsData(PostsData postsData)
        {
            _context.PostsData.Add(postsData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostsData", new { id = postsData.PostId }, postsData);
        }

        // DELETE: api/PostsData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostsData>> DeletePostsData(int id)
        {
            var postsData = await _context.PostsData.FindAsync(id);
            if (postsData == null)
            {
                return NotFound();
            }

            _context.PostsData.Remove(postsData);
            await _context.SaveChangesAsync();

            return postsData;
        }

        private bool PostsDataExists(int id)
        {
            return _context.PostsData.Any(e => e.PostId == id);
        }
    }
}
