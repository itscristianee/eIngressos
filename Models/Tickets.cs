using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eIngressos.Models
{
    public class Tickets
    {
        public Tickets()
        {
            UserTickets = new HashSet<UserTickets>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Vendido")]
        [Required]
        public bool Sold { get; set; }

        public int Quantity { get; set; }
        
        public decimal Total { get; set; }

        [Display(Name = "Data da Compra")]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public Sessions Session { get; set; }

        public ICollection<UserTickets> UserTickets { get; set; }
    }
}