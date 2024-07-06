using Ing.Data;
using Ing.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ing.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Display(Name = "Título")]
        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Descrição")]
        [Required]
        public string Description { get; set; }
        
        [Display(Name = "Poster")]
        public string? ImageURL { get; set; }// o ? torna o preenchimento facultativo
        
        [Display(Name = "Duração (Minutos)")]
        [Required]
        public int Duration { get; set; }
        
        [Display(Name = "Classificação Etária")]
        [Required]
        public int AgeRating { get; set; }

        public string Producer { get; set; }
        
        [Display(Name = "Categoria")]
        [Required]
        public MovieCategory Category { get; set; }
        
        [Display(Name = "Inicio de exibição")]
        [Required]
        public DateTime StartDate { get; set; }
        

        [Display(Name = "Fim de exibição?")]
        [Required]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O {0} é obrigatória.")]
        [RegularExpression("[0-9]+[.,]?[0-9]{0,2}", ErrorMessage = "Digitos numéricos separados por , ou .")]
        public double Price { get; set; }
        //Relationship between tables
        
        [Display(Name = "Sessões")]

        public ICollection<Session> Sessions { get; set; }

        
        //Actor e Movie
        [Display(Name ="Actores")]
        public ICollection<ActorMovie> ActorsMovies { get; set; }
        
        

        
    }
}