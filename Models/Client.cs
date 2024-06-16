using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Ing.Models;

public class Client
{
    [Key]

    [StringLength(9)]  // Limita o tamanho máximo do campo
    public string NIF { get; set; }

    [StringLength(255)]  // Limita o tamanho máximo do campo
    public string Name { get; set; }

    [Required(ErrorMessage = "0 {0} é de preenchimento obrigatório!")]  // Campo obrigatório
    [EmailAddress(ErrorMessage = "Escreva um {0} válido, por favor.")]  // Valida se o campo é um email válido
    public string Email { get; set; }

    [Display(Name = "Endereço")]  // Define o nome de exibição para "Endereço"
    [StringLength(255)]  // Limita o tamanho máximo do campo
    public string Address { get; set; }


    [DataType(DataType.Date)] // informa a View de como deve tratar este atributo
    [DisplayFormat(ApplyFormatInEditMode = true,
                    DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly BirthDate{ get; set; }

    [Display(Name = "Telemóvel no formato internacional")]  // Define o nome de exibição para "Telemóvel"
    [RegularExpression(@"^(00|\+)[1-9]\d{1,3}\d{6,14}$",
        ErrorMessage = "Por favor, insira um número de telemóvel no formato internacional válido.")]
    public string Phone { get; set; }
}