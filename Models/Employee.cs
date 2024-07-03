using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ing.Data.Enums;

namespace Ing.Models;

public class Employee: Person
{
    
    
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly DateStart { get; set; }
    
    public UserType EmployeePosition{ get; set; }
    
}