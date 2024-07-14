using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eIngressos.Models
{
    public class LoginVM
    {
        [Display(Name = "Email ")]
        [Required(ErrorMessage = "Email é obrigatorio!")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
