using eIngressos.Data;
using eIngressos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ActedInsController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<ActedInsController> _logger;

    public ActedInsController(AppDbContext context, ILogger<ActedInsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: ActedIns
    public async Task<IActionResult> Index()
    {
        var appDbContext = _context.ActedIns.Include(a => a.Actor).Include(a => a.Movie);
        return View(await appDbContext.ToListAsync());
    }

    // GET: ActedIns/Details/5
    public async Task<IActionResult> Details(int? movieId, int? actorId)
    {
        if (movieId == null || actorId == null)
        {
            return NotFound();
        }

        var actedIn = await _context.ActedIns
            .Include(a => a.Actor)
            .Include(a => a.Movie)
            .FirstOrDefaultAsync(m => m.MovieId == movieId && m.ActorId == actorId);
        if (actedIn == null)
        {
            return NotFound();
        }

        return View(actedIn);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name");
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MovieId,ActorId,Character,Role")] ActedIn actedIn)
    {
        _logger.LogInformation("Create POST method called");

        if (ModelState.IsValid)
        {
            _logger.LogInformation("ModelState is valid");
            try
            {
                _context.ActedIns.Add(actedIn);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ActedIn record saved successfully");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the ActedIn record.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the record. Please try again.");
            }
        }
        else
        {
            _logger.LogWarning("ModelState is invalid");
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogWarning($"Key: {state.Key}, Error: {error.ErrorMessage}, Exception: {error.Exception}");
                }
            }
        }

        ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name", actedIn.ActorId);
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", actedIn.MovieId);
        return View(actedIn);
    }

    // GET: ActedIns/Edit/5
    public async Task<IActionResult> Edit(int? movieId, int? actorId)
    {
        if (movieId == null || actorId == null)
        {
            return NotFound();
        }

        var actedIn = await _context.ActedIns
            .Include(a => a.Actor)
            .Include(a => a.Movie)
            .FirstOrDefaultAsync(m => m.MovieId == movieId && m.ActorId == actorId);
            
        if (actedIn == null)
        {
            return NotFound();
        }

        ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name", actedIn.ActorId);
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", actedIn.MovieId);
        return View(actedIn);
    }

    // POST: ActedIns/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int movieId, int actorId, [Bind("MovieId,ActorId,Character,Role")] ActedIn actedIn)
    {
        if (movieId != actedIn.MovieId || actorId != actedIn.ActorId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(actedIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActedInExists(actedIn.MovieId, actedIn.ActorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name", actedIn.ActorId);
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", actedIn.MovieId);
        return View(actedIn);
    }

    // GET: ActedIns/Delete/5
    public async Task<IActionResult> Delete(int? movieId, int? actorId)
    {
        if (movieId == null || actorId == null)
        {
            return NotFound();
        }

        var actedIn = await _context.ActedIns
            .Include(a => a.Actor)
            .Include(a => a.Movie)
            .FirstOrDefaultAsync(m => m.MovieId == movieId && m.ActorId == actorId);
        if (actedIn == null)
        {
            return NotFound();
        }

        return View(actedIn);
    }

    // POST: ActedIns/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int movieId, int actorId)
    {
        var actedIn = await _context.ActedIns.FirstOrDefaultAsync(m => m.MovieId == movieId && m.ActorId == actorId);
        if (actedIn != null)
        {
            _context.ActedIns.Remove(actedIn);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool ActedInExists(int movieId, int actorId)
    {
        return _context.ActedIns.Any(e => e.MovieId == movieId && e.ActorId == actorId);
    }
}
