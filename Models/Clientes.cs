using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Ing.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }[Required]  // Campo obrigatório
   
    [StringLength(255)]  // Limita o tamanho máximo do campo
    public string Nome { get; set; }  

    [StringLength(9)]  // Limita o tamanho máximo do campo
    public string NIF { get; set; }  

    [Required]  // Campo obrigatório
    [EmailAddress]  // Valida se o campo é um email válido
    public string Email { get; set; } 

    [Display(Name = "Endereço")]  // Define o nome de exibição para "Endereço"
    [StringLength(255)]  // Limita o tamanho máximo do campo
    public string Endereco { get; set; } 
    
    //por fazer 
    public DateOnly DataNasc { get; set; }  
    
    [Display(Name = "Telemóvel no formato internacional")]  // Define o nome de exibição para "Telemóvel"
    [RegularExpression( @"^(00|\+)[1-9]\d{1,3}\d{6,14}$",
        ErrorMessage = "Por favor, insira um número de telemóvel no formato internacional válido.")]
    public string Telemovel { get; set; } 
    
   
    // Método para validar o número de telefone com a expressão regular
    public bool IsTelemovelValido()
    {
        if (string.IsNullOrEmpty(Telemovel))
            return true; // Número de telefone vazio é considerado válido

        // Expressão regular para validar o número de telefone internacional
        string pattern = @"^(00|\+)[1-9]\d{1,3}\d{6,14}$";
        return Regex.IsMatch(Telemovel, pattern);
    }
}