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
    public class FriendDataController : ControllerBase
    {
        private readonly EvalContext _context;

        public FriendDataController(EvalContext context)
        {
            _context = context;
        }

        // GET: api/FriendData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendData>>> GetFriendData()
        {
            return await _context.FriendData.ToListAsync();
        }

        // GET: api/FriendData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendData>> GetFriendData(int id)
        {
            var friendData = await _context.FriendData.FindAsync(id);

            if (friendData == null)
            {
                return NotFound();
            }

            return friendData;
        }

        // PUT: api/FriendData/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendData(int id, FriendData friendData)
        {
            if (id != friendData.FriendId)
            {
                return BadRequest();
            }

            _context.Entry(friendData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendDataExists(id))
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

        // POST: api/FriendData
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FriendData>> PostFriendData(FriendData friendData)
        {
            _context.FriendData.Add(friendData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriendData", new { id = friendData.FriendId }, friendData);
        }

        // DELETE: api/FriendData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendData>> DeleteFriendData(int id)
        {
            var friendData = await _context.FriendData.FindAsync(id);
            if (friendData == null)
            {
                return NotFound();
            }

            _context.FriendData.Remove(friendData);
            await _context.SaveChangesAsync();

            return friendData;
        }

        private bool FriendDataExists(int id)
        {
            return _context.FriendData.Any(e => e.FriendId == id);
        }
    }
}
