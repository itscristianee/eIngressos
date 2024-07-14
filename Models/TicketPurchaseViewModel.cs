using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eIngressos.Models
{
    public class TicketPurchaseViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        public int SessionId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public string? UserId { get; set; }
        
        [NotMapped]
        
        public List<Tickets> PurchasedTickets { get; set; } = new List<Tickets>();
    }
}