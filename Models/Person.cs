using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Ing.Models;

public class Person : IdentityUser
{
    [Key]
    [StringLength(9)]
    public string NIF { get; set; }
        
    [StringLength(255)]
    public string Name { get; set; }
        
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
    [EmailAddress(ErrorMessage = "Escreva um {0} válido, por favor.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "A Password é de preenchimento obrigatório!")]
    [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly BirthDate { get; set; }

    [Display(Name = "Telemóvel no formato internacional")]
    [RegularExpression(@"^(00|\+)[1-9]\d{1,3}\d{6,14}$", ErrorMessage = "Por favor, insira um número de telemóvel no formato internacional válido.")]
    public string Phone { get; set; }
    
    /// <summary>
    /// atributo para funcionar como FK
    /// no relacionamento entre a 
    /// base de dados do 'negócio' 
    /// e a base de dados da 'autenticação'
    /// </summary>
    [StringLength(40)]
    public string UserId { get; set; }
}