using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eIngressos.Data;
using eIngressos.Models;

namespace eIngressos.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersApi : ControllerBase
    {
        private readonly AppDbContext _context;

        public TheatersApi(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TheatersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theaters>>> GetTheaters()
        {
            return await _context.Theaters.ToListAsync();
        }

        // GET: api/TheatersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theaters>> GetTheaters(int id)
        {
            var theaters = await _context.Theaters.FindAsync(id);

            if (theaters == null)
            {
                return NotFound();
            }

            return theaters;
        }

        // PUT: api/TheatersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheaters(int id, Theaters theaters)
        {
            if (id != theaters.Id)
            {
                return BadRequest();
            }

            _context.Entry(theaters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheatersExists(id))
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

        // POST: api/TheatersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theaters>> PostTheaters(Theaters theaters)
        {
            _context.Theaters.Add(theaters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheaters", new { id = theaters.Id }, theaters);
        }

        // DELETE: api/TheatersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheaters(int id)
        {
            var theaters = await _context.Theaters.FindAsync(id);
            if (theaters == null)
            {
                return NotFound();
            }

            _context.Theaters.Remove(theaters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheatersExists(int id)
        {
            return _context.Theaters.Any(e => e.Id == id);
        }
    }
}
