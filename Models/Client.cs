using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Ing.Models;

public class Client : Person
{
    
    
    [Display(Name = "Endereço")]
    [StringLength(255)]
    public string Address { get; set; }

   
}