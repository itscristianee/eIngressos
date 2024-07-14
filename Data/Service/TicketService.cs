using System;
using System.Threading.Tasks;
using eIngressos.Data;
using eIngressos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace eIngressos.Services
{
    public class TicketService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<UsersApp> _userManager;

        public TicketService(AppDbContext context, UserManager<UsersApp> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Tickets> SellTicket(int sessionId, int qnt, decimal totalPrice, string userId = null)
        {
            var ticket = new Tickets
            {
                SessionId = sessionId,
                Sold = true,
                Quantity = qnt,
                Total = totalPrice,
                PurchaseDate = DateTime.Now,
                Session = await _context.Sessions.FindAsync(sessionId)
            };

            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var userTicket = new UserTickets
                    {
                        User = user,
                        Ticket = ticket
                    };
                    _context.UserTickets.Add(userTicket);
                }
            }

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<Tickets> GetTicketById(int ticketId)
        {
            return await _context.Tickets
                .Include(t => t.Session)
                .Include(t => t.UserTickets)
                .ThenInclude(ut => ut.User)
                .FirstOrDefaultAsync(t => t.Id == ticketId);
        }
    }
}