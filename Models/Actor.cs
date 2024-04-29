
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ing.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "About")]
        public string Bio { get; set; }
        [Display(Name ="Profile Picture")]
        public string ProfilePictureURL { get; set; }
        public List<Actor_Filme> Actores_Filmes { get; set; }
    }
}
