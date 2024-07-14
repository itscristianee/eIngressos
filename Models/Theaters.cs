using System.ComponentModel.DataAnnotations;

namespace eIngressos.Models;

public class Theaters
{
    public Theaters() {
        Sessions = new HashSet<Sessions>();
    }
    public int Id { get; set; }
    [Display(Name = "Nome")]
    public required string Name { get; set; }

    [Display(Name = "Lotação")]
    public required int Capacity {get; set;}
    
    public ICollection<Sessions> Sessions { get; set; } 
}