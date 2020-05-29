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
    public class PostsDetailsController : ControllerBase
    {
        private readonly EvalContext _context;

        public PostsDetailsController(EvalContext context)
        {
            _context = context;
        }

        // GET: api/PostsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostsDetails>>> GetPostsDetails()
        {
            return await _context.PostsDetails.ToListAsync();
        }

        // GET: api/PostsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostsDetails>> GetPostsDetails(int id)
        {
            var postsDetails = await _context.PostsDetails.FindAsync(id);

            if (postsDetails == null)
            {
                return NotFound();
            }

            return postsDetails;
        }

        // PUT: api/PostsDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostsDetails(int id, PostsDetails postsDetails)
        {
            if (id != postsDetails.DetailsId)
            {
                return BadRequest();
            }

            _context.Entry(postsDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsDetailsExists(id))
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

        // POST: api/PostsDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostsDetails>> PostPostsDetails(PostsDetails postsDetails)
        {
            _context.PostsDetails.Add(postsDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostsDetails", new { id = postsDetails.DetailsId }, postsDetails);
        }

        // DELETE: api/PostsDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostsDetails>> DeletePostsDetails(int id)
        {
            var postsDetails = await _context.PostsDetails.FindAsync(id);
            if (postsDetails == null)
            {
                return NotFound();
            }

            _context.PostsDetails.Remove(postsDetails);
            await _context.SaveChangesAsync();

            return postsDetails;
        }

        private bool PostsDetailsExists(int id)
        {
            return _context.PostsDetails.Any(e => e.DetailsId == id);
        }
    }
}
