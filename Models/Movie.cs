﻿using Ing.Data;
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
        
        
        /*Enum tipo filme categoria
             Tipo de valor definido pelo usuário usado para representar uma
             lista de constantes inteiras nomeadas
        */
        [Display(Name = "Categoria")]
        [Required]
        public MovieCategory Category { get; set; }
        
        [Display(Name = "Data de adição")]
        [Required]
        public DateTime DateAdd { get; set; }

        [Display(Name = "Em exibição?")]
        [Required]
        public bool InExib { get; set; }
        
        //Relacionamento entre tabelas
        
        //Actor e Movie
        [Display(Name ="Actores")]
        public ICollection<ActorMovie> ActorsMovies { get; set; }

        
    }
}