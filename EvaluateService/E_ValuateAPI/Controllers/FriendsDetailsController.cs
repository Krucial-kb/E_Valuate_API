using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_ValuateAPI.DataModels;

namespace E_ValuateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsDetailsController : ControllerBase
    {
        private readonly EvalContext _context;

        public FriendsDetailsController(EvalContext context)
        {
            _context = context;
        }

        // GET: api/FriendsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendsDetails>>> GetFriendsDetails()
        {
            return await _context.FriendsDetails.ToListAsync();
        }

        // GET: api/FriendsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendsDetails>> GetFriendsDetails(int id)
        {
            var friendsDetails = await _context.FriendsDetails.FindAsync(id);

            if (friendsDetails == null)
            {
                return NotFound();
            }

            return friendsDetails;
        }

        // PUT: api/FriendsDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendsDetails(int id, FriendsDetails friendsDetails)
        {
            if (id != friendsDetails.DetailsId)
            {
                return BadRequest();
            }

            _context.Entry(friendsDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendsDetailsExists(id))
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

        // POST: api/FriendsDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FriendsDetails>> PostFriendsDetails(FriendsDetails friendsDetails)
        {
            _context.FriendsDetails.Add(friendsDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriendsDetails", new { id = friendsDetails.DetailsId }, friendsDetails);
        }

        // DELETE: api/FriendsDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendsDetails>> DeleteFriendsDetails(int id)
        {
            var friendsDetails = await _context.FriendsDetails.FindAsync(id);
            if (friendsDetails == null)
            {
                return NotFound();
            }

            _context.FriendsDetails.Remove(friendsDetails);
            await _context.SaveChangesAsync();

            return friendsDetails;
        }

        private bool FriendsDetailsExists(int id)
        {
            return _context.FriendsDetails.Any(e => e.DetailsId == id);
        }
    }
}
