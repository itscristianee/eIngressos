using System.ComponentModel.DataAnnotations.Schema;

namespace eIngressos.Models
{
    public class UserTickets
    {
        [ForeignKey(nameof(User))]
        public string Name { get; set; }  // Ensure type is string
        public UsersApp User { get; set; }

        [ForeignKey(nameof(Ticket))]
        public int TicketId { get; set; }
        public Tickets Ticket { get; set; }
    }
}