using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eIngressos.Data.Enums;

namespace eIngressos.Models;

public class Movies
{
    public Movies() {
        Sessions = new HashSet<Sessions>();
        Actors = new HashSet<ActedIn>();
    }
    public int Id { get; set; }

    [Display(Name = "Título")]
    [Required]
    public required string Title { get; set; }
        
    [Display(Name = "Descrição")]
    [Required]
    public required string Description { get; set; }
        
    [Display(Name = "Poster")]
    public required string Image { get; set; }
        
    [Display(Name = "Duração (Minutos)")]
    [Required]
    public required int Duration { get; set; }
        
    [Display(Name = "Classificação Etária")]
    [Required]
    public required int AgeRating { get; set; }

    public required string Producer { get; set; }
        
    [Display(Name = "Categoria")]
    [Required]
    public required MovieCategory Category { get; set; }

    [NotMapped]
    [StringLength(8)]
    [Display(Name = "Preço")]
    [Required(ErrorMessage = "A {0} é obrigatória.")]
    [RegularExpression("[0-9]+[.,]?[0-9]{0,2}", ErrorMessage = "só aceita digitos numéricos, separados por . ou por ,")]
    public string PriceAux { get; set; }

    public decimal Price { get; set; }
    
    public required ICollection<ActedIn> Actors { get; set; }

    public ICollection<Sessions> Sessions { get; set; }
}