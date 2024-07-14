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
    public class ActorsApi : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActorsApi(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ActorsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actors>>> GetActors()
        {
            return await _context.Actors.ToListAsync();
        }

        // GET: api/ActorsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actors>> GetActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

        // PUT: api/ActorsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actors actors)
        {
            if (id != actors.Id)
            {
                return BadRequest();
            }

            _context.Entry(actors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/ActorsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actors>> PostActor(Actors actors)
        {
            _context.Actors.Add(actors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = actors.Id }, actors);
        }

        // DELETE: api/ActorsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
