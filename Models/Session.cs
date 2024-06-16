using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ing.Models;

public class Session
{
    [Key]
    public int SessaoId { get; set; }  // Chave primária única para cada sessão


    [Required]
    [DataType(DataType.Date)] // informa a View de como deve tratar este atributo
    [DisplayFormat(ApplyFormatInEditMode = true,
                     DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly Data { get; set; }  // Data e hora de início da sessão

    [Required]
    public TimeOnly Hora { get; set; }     // Data e hora de fim da sessão


    [Display(Name = "Capacidade")]
    public int NLugares { get; set; }  // o n° de lugares
    //Relacionamento entre tabelas
    
    //Movie e sessao
    [Display(Name = "Movie")]
    [ForeignKey(nameof(Movie))]
    public int FilmeId { get; set; }
    public Movie Movie { get; set; }


}