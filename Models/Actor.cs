
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ing.Models
{
    public class Actor
    {
        [Key]
        
        public int ActorId { get; set; }
        
       [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(60)]
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
