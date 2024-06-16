using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ing.Models;

public class Ticket
{
    [Key]

    public int IngressoId { get; set; }

    [Display(Name = "Preço")]
    [Required(ErrorMessage = "O {0} é obrigatória.")]
    [RegularExpression("[0-9]+[.,]?[0-9]{0,2}", ErrorMessage = "Digitos numéricos separados por , ou .")]
    public decimal Price { get; set; }

    [Display(Name = "Hora de entrada")]
    public TimeOnly EntranceTime { get; set; }
    
    [Display(Name = "Data da compra")]
    [DataType(DataType.Date)] // informa a View de como deve tratar este atributo
      [DisplayFormat(ApplyFormatInEditMode = true,
                     DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly DatePurchase { get; set; }
    
    //Relacionamento entre tabelas

    //Session e Ticket
    [Display(Name = "Sessões")]
    [ForeignKey(nameof(Session))]
    public int SessaoId { get; set; }  // Chave primária única para cada sessão
    public Session Session { get; set; }
}