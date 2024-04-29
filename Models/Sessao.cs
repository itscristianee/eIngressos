using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ing.Models;

public class Sessao
{
    [Key]
    public int SessaoId { get; set; }  // Chave primária única para cada sessão

    [Required]
    [ForeignKey("Filmes")]
    public int FilmeId { get; set; }  // Chave estrangeira do filme associado à sessão
    public Filmes Filmes { get; set; }  // Propriedade de navegação para o filme

    
    [Required]
    public DateOnly Data { get; set; }  // Data e hora de início da sessão

    [Required]
    public TimeOnly Hora { get; set; }     // Data e hora de fim da sessão

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Preco { get; set; }   
    
    public int nLugares { get; set; }  // o n° de lugares
}