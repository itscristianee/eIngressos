using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eIngressos.Data;
using eIngressos.Models;

namespace eIngressos.Controllers
{
    public class SessionsController : Controller
    {
        private readonly AppDbContext _context;

        public SessionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var sessions = await _context.Sessions
                .Include(s => s.Theater)
                .Include(s => s.Movie)
                .ToListAsync();
            return View(sessions);
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewBag.Theaters = new SelectList(_context.Theaters, "Id", "Name");
            ViewBag.Movies = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TheaterId,MovieId,SessionDateTime")] Sessions sessions)
        {
            // Retrieve the Theater and Movie based on the provided IDs
            if (sessions.TheaterId > 0)
            {
                sessions.Theater = await _context.Theaters.FindAsync(sessions.TheaterId);
            }

            if (sessions.MovieId > 0)
            {
                sessions.Movie = await _context.Movies.FindAsync(sessions.MovieId);
            }

            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Key: {state.Key}, Error: {error.ErrorMessage}, Exception: {error.Exception}");
                    }
                }

                ViewBag.Theaters = new SelectList(_context.Theaters, "Id", "Name");
                ViewBag.Movies = new SelectList(_context.Movies, "Id", "Title");
                return View(sessions);
            }

            _context.Add(sessions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            ViewBag.Theaters = new SelectList(_context.Theaters, "Id", "Name", session.TheaterId);
            ViewBag.Movies = new SelectList(_context.Movies, "Id", "Title", session.MovieId);

            return View(session);
        }

// POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SessionDateTime,TheaterId,MovieId")] Sessions sessions)
        {
            if (id != sessions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(sessions.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Theaters = new SelectList(_context.Theaters, "Id", "Name", sessions.TheaterId);
            ViewBag.Movies = new SelectList(_context.Movies, "Id", "Title", sessions.MovieId);

            return View(sessions);
        }
        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }
    }
}
