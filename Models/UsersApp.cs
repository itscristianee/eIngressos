using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace eIngressos.Models
{
    public class UsersApp : IdentityUser
    {
        public UsersApp()
        {
            UserTickets = new HashSet<UserTickets>();
        }

        [Display(Name = "Nome Completo")]
        public required string Name { get; set; }

        public ICollection<UserTickets> UserTickets { get; set; }
    }
}