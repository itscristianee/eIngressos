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
    public class Filmes
    {
        [Key]
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        
        [Display(Name = "Preço")]
        [Required]
        public double Preco { get; set; }
        
        public string ImageURL { get; set; }
        
        [Display(Name = "Duração (Minutos)")]
        [Required]
        public int Duracao { get; set; }
        
        [Display(Name = "Classificação Etária")]
        [Required]
        public int ClassificacaoEtaria { get; set; }
        public string Produtor { get; set; }
        
        
        /*Enum tipo filme categoria
             Tipo de valor definido pelo usuário usado para representar uma
             lista de constantes inteiras nomeadas
        */
        [Display(Name = "Categoria")]
        [Required]
        public FilmeCategoria FilmeCategoria { get; set; }
        
        [Display(Name = "Data de adição")]
        [Required]
        public DateTime DataAdd { get; set; }

        [Display(Name = "Em exibição?")]
        [Required]
        public bool EmExib { get; set; }
        
        //Relacionamento entre tabelas
        
        //Actor e Filmes
        public List<Actor_Filme> Actores_Filmes { get; set; }

        //Sessao
        public int SessaoId { get; set; }
        [ForeignKey("SessaoId")]
        public Sessao Sessao { get; set; }

        
    }
}