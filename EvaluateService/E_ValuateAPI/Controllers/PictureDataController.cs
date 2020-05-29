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
    public class PictureDataController : ControllerBase
    {
        private readonly EvalContext _context;

        public PictureDataController(EvalContext context)
        {
            _context = context;
        }

        // GET: api/PictureData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PictureData>>> GetPictureData()
        {
            return await _context.PictureData.ToListAsync();
        }

        // GET: api/PictureData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PictureData>> GetPictureData(int id)
        {
            var pictureData = await _context.PictureData.FindAsync(id);

            if (pictureData == null)
            {
                return NotFound();
            }

            return pictureData;
        }

        // PUT: api/PictureData/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPictureData(int id, PictureData pictureData)
        {
            if (id != pictureData.PictureId)
            {
                return BadRequest();
            }

            _context.Entry(pictureData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PictureDataExists(id))
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

        // POST: api/PictureData
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PictureData>> PostPictureData(PictureData pictureData)
        {
            _context.PictureData.Add(pictureData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPictureData", new { id = pictureData.PictureId }, pictureData);
        }

        // DELETE: api/PictureData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PictureData>> DeletePictureData(int id)
        {
            var pictureData = await _context.PictureData.FindAsync(id);
            if (pictureData == null)
            {
                return NotFound();
            }

            _context.PictureData.Remove(pictureData);
            await _context.SaveChangesAsync();

            return pictureData;
        }

        private bool PictureDataExists(int id)
        {
            return _context.PictureData.Any(e => e.PictureId == id);
        }
    }
}
