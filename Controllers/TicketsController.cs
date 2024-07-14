using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eIngressos.Data;
using eIngressos.Models;
using eIngressos.Services;
using Microsoft.AspNetCore.Identity;

namespace eIngressos.Controllers
{
    [Route("Tickets")]
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TicketService _ticketService;
        private readonly UserManager<UsersApp> _userManager;

        public TicketsController(AppDbContext context, TicketService ticketService, UserManager<UsersApp> userManager)
        {
            _context = context;
            _ticketService = ticketService;
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Session)
                .ThenInclude(s => s.Movie)
                .ToListAsync();
            return View(tickets);
        }


        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Session)
                .ThenInclude(s => s.Movie)
                .Include(t => t.Session)
                .ThenInclude(s => s.Theater)
                .Include(t => t.UserTickets)
                .ThenInclude(ut => ut.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }



        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .Include(t => t.Session)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        [HttpPost("Delete/{id}"), ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets != null)
            {
                _context.Tickets.Remove(tickets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }

        [HttpGet("Purchase")]
        public async Task<IActionResult> Purchase()
        {
            var movies = _context.Movies.ToList();
            ViewBag.Movies = new SelectList(movies, "Id", "Title");

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserName = User.Identity.Name;
            }
            return View();
        }


        [HttpGet("MyPurchase")]
        public async Task<IActionResult> MyPurchase()
        {
            // Obtém o nome do usuário logado
            var userName = _userManager.GetUserName(User);

            // Obtém os tickets comprados pelo usuário logado
            var userTickets = await _context.UserTickets
                .Include(ut => ut.Ticket)
                .ThenInclude(t => t.Session)
                .ThenInclude(s => s.Movie)
                .Where(ut => ut.User.UserName == userName && ut.Ticket.Sold)
                .Select(ut => ut.Ticket)
                .ToListAsync();

            // Cria o ViewModel com os tickets comprados
            var viewModel = new TicketPurchaseViewModel
            {
                PurchasedTickets = userTickets
            };

            return View(viewModel);
        }


        [HttpGet("GetSessions/{movieId}")]
        public async Task<IActionResult> GetSessions(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions
                .Where(s => s.MovieId == movieId)
                .Select(s => new { s.Id, s.SessionDateTime })
                .ToListAsync();

            return Json(new { sessions, movieImage = movie.Image });
        }


        [HttpPost("Purchase")]
        public async Task<IActionResult> Purchase(TicketPurchaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var session = await _context.Sessions
                    .Include(s => s.Movie)
                    .Include(s => s.Theater)
                    .FirstOrDefaultAsync(s => s.Id == model.SessionId);

                if (session == null)
                {
                    ModelState.AddModelError(string.Empty, "Session not found.");
                    return View(model);
                }

                var totalTicketsSold = _context.Tickets
                    .Where(t => t.SessionId == model.SessionId && t.Sold)
                    .Sum(t => (int?)t.Quantity) ?? 0;

                if (totalTicketsSold + model.Quantity > session.Theater.Capacity)
                {
                    ModelState.AddModelError(string.Empty, "Not enough tickets available.");
                    return View(model);
                }

                var price = session.Movie.Price * model.Quantity;
                var ticket = await _ticketService.SellTicket(model.SessionId, model.Quantity, price, model.UserId);
                return RedirectToAction("Confirmation", new { ticketId = ticket.Id });
            }

            return View(model);
        }

        [HttpGet("Confirmation")]
        public async Task<IActionResult> Confirmation(int ticketId)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Session)
                .ThenInclude(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == ticketId);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
