using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eIngressos.Models {
    [PrimaryKey(nameof(MovieId), nameof(ActorId))] // PK para EF >= 7.0

    public class ActedIn
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public required Movies Movie { get; set; }

        [ForeignKey(nameof(Actor))]
        public int ActorId { get; set; }
        public required Actors Actor { get; set; }

        public required string Character { get; set; }
        public required string Role { get; set; }
    }
}
