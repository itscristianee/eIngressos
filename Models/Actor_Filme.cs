namespace Ing.Models
{
    public class Actor_Filme
    {
       // Precisamos disso para entrar na mesa de atores e movies
        public int FilmeId { get; set; }
        public Filmes Filmes { get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
        public String Papel { get; set; }
    }
}
