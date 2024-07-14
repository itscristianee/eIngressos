using System.ComponentModel.DataAnnotations;
namespace eIngressos.Models;

public class Actors
{
    public Actors() {
        ActedIns = new HashSet<ActedIn>();
    }
    public int Id { get; set; }
        
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(60)]
    [Display(Name = "Nome")]
    public required string Name { get; set; }

    [Display(Name = "About")]
    public required string Bio { get; set; }

   
    public required string Photo { get; set; }

   
    public required ICollection<ActedIn> ActedIns { get; set; }
}