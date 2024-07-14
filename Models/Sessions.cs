using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eIngressos.Models {
    public class Sessions {
        
        public Sessions() {
            Tickets = new HashSet<Tickets>();
        }
        [Key] 
        public int Id { get; set; }

        [ForeignKey(nameof(Theater))] 
        public int TheaterId { get; set; }
        
        public Theaters Theater { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movies Movie { get; set; }

        [Display(Name = "Data e Hora da Sessão")]
        [Required]
        public required DateTime SessionDateTime { get; set; }
        
        
        public required ICollection<Tickets> Tickets { get; set; }
    }
}
