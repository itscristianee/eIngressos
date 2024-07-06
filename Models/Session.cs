using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ing.Models;

public class Session
{
    [Key]
    public int SessaoId { get; set; }


    [Required]
    [DataType(DataType.Date)] 
    [DisplayFormat(ApplyFormatInEditMode = true,
                     DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly Data { get; set; }  

    [Required]
    public TimeOnly Hora { get; set; }     


    [Display(Name = "Capacidade")]
    public int QuantitySits { get; set; }  
    
    //Movie e sessao
    [Display(Name = "Movie")]
    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    


}