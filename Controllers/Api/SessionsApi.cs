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
    public class SessionsApi : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionsApi(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SessionsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sessions>>> GetSessions()
        {
            return await _context.Sessions.ToListAsync();
        }

        // GET: api/SessionsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sessions>> GetSessions(int id)
        {
            var sessions = await _context.Sessions.FindAsync(id);

            if (sessions == null)
            {
                return NotFound();
            }

            return sessions;
        }

        // PUT: api/SessionsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessions(int id, Sessions sessions)
        {
            if (id != sessions.Id)
            {
                return BadRequest();
            }

            _context.Entry(sessions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionsExists(id))
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

        // POST: api/SessionsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sessions>> PostSessions(Sessions sessions)
        {
            _context.Sessions.Add(sessions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessions", new { id = sessions.Id }, sessions);
        }

        // DELETE: api/SessionsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessions(int id)
        {
            var sessions = await _context.Sessions.FindAsync(id);
            if (sessions == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(sessions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessionsExists(int id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }
    }
}
