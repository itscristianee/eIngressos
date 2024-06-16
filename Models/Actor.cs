
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ing.Models
{
    public class Actor
    {
        [Key]
        
        public int ActorId { get; set; }
        
        [Required(ErrorMessage = "0 {0} é de preenchimento obrigatório!")]  // Campo obrigatório
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "About")]
        public string Bio { get; set; }

        [Display(Name ="Foto de perfil")]
        public string? ProfilePicture { get; set; }// o ? torna o preenchimento facultativo
        
        [Display(Name ="Movie em que participou")]
        public ICollection<ActorMovie> ActorsMovies { get; set; }
    }
}
